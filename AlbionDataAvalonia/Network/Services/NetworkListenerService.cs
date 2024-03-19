﻿using Albion.Network;
using AlbionDataAvalonia.Network.Handlers;
using AlbionDataAvalonia.Network.Models;
using AlbionDataAvalonia.State;
using PacketDotNet;
using Serilog;
using SharpPcap;
using System;
using System.Linq;
using System.Threading;

namespace AlbionDataAvalonia.Network.Services
{
    public class NetworkListenerService : IDisposable
    {
        private IPhotonReceiver? receiver;
        private CaptureDeviceList? devices;
        private readonly Uploader _uploader;
        private readonly PlayerState _playerState;

        public NetworkListenerService(Uploader uploader, PlayerState playerState)
        {
            _uploader = uploader;
            _playerState = playerState;
        }

        public void Run()
        {
            ReceiverBuilder builder = ReceiverBuilder.Create();

            //ADD HANDLERS HERE
            //RESPONSE
            builder.AddResponseHandler(new AuctionGetOffersResponseHandler(_uploader, _playerState));
            builder.AddResponseHandler(new AuctionGetRequestsResponseHandler(_uploader, _playerState));
            builder.AddResponseHandler(new AuctionGetItemAverageStatsResponseHandler(_uploader, _playerState));
            builder.AddResponseHandler(new JoinResponseHandler(_playerState));
            builder.AddResponseHandler(new AuctionGetGoldAverageStatsResponseHandler(_uploader));
            //REQUEST
            builder.AddRequestHandler(new AuctionGetItemAverageStatsRequestHandler(_playerState));

            receiver = builder.Build();

            if (receiver == null)
            {
                Log.Error("Failed to create network receiver");
                return;
            }

            Log.Debug("Starting...");

            devices = CaptureDeviceList.New();

            foreach (var device in devices)
            {
                new Thread(() =>
                {
                    Log.Debug("Open... {Device}", device.Description);

                    device.OnPacketArrival += new PacketArrivalEventHandler(PacketHandler);
                    device.Open(new DeviceConfiguration
                    {
                        Mode = DeviceModes.MaxResponsiveness,
                        ReadTimeout = 5000
                    });
                    device.Filter = "(host 5.45.187 or host 5.188.125) and udp port 5056";
                    device.StartCapture();
                })
                .Start();
            }

            Log.Information("Listening to Albion network packages!");

            return;
        }
        private void PacketHandler(object sender, PacketCapture e)
        {
            if (receiver == null)
            {
                Log.Error("Receiver is null");
                return;
            }
            try
            {
                UdpPacket packet = Packet.ParsePacket(e.GetPacket().LinkLayerType, e.GetPacket().Data).Extract<UdpPacket>();
                if (packet != null)
                {
                    var srcIp = (packet.ParentPacket as IPv4Packet)?.SourceAddress?.ToString();
                    if (string.IsNullOrEmpty(srcIp))
                    {
                        Log.Verbose("Packet Source IP null or empty, ignoring");
                        return;
                    }
                    var server = AlbionServers.GetAllServers().SingleOrDefault(x => srcIp.Contains(x.IpBase));
                    if (server is not null)
                    {
                        Log.Verbose("Packet from {server} server from IP {ip}", server.Name, srcIp);
                        _playerState.AlbionServer = server;
                    }
                    receiver.ReceivePacket(packet.PayloadData);
                }
            }
            catch (Exception ex)
            {
                Log.Debug(ex.Message);
            }
        }

        private void Cleanup()
        {
            // Close network devices, flush logs, etc.
            if (devices is not null)
            {
                foreach (var device in devices)
                {
                    device.StopCapture();
                    device.Close();
                    Log.Debug("Close... {Device}", device.Description);
                }
            }
        }

        public void Dispose()
        {
            Cleanup();
            Log.Information("Stopped {type}!", nameof(NetworkListenerService));
        }
    }
}
