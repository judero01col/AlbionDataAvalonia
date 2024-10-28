﻿namespace AlbionDataAvalonia.Network;
public enum OperationCodes
{
    Unused,

    Ping,

    Join,

    VersionedOperation,

    CreateAccount,

    Login,

    CreateGuestAccount,

    SendCrashLog,

    SendTraceRoute,

    SendVfxStats,

    SendGamePingInfo,

    CreateCharacter,

    DeleteCharacter,

    SelectCharacter,

    AcceptPopups,

    RedeemKeycode,

    GetGameServerByCluster,

    GetShopPurchaseUrl,

    GetReferralSeasonDetails,

    GetReferralLink,

    GetShopTilesForCategory,

    Move,

    AttackStart,

    CastStart,

    CastCancel,

    TerminateToggleSpell,

    ChannelingCancel,

    AttackBuildingStart,

    InventoryDestroyItem,

    InventoryMoveItem,

    InventoryRecoverItem,

    InventoryRecoverAllItems,

    InventorySplitStack,

    InventorySplitStackInto,

    GetClusterData,

    ChangeCluster,

    ConsoleCommand,

    ChatMessage,

    ReportClientError,

    RegisterToObject,

    UnRegisterFromObject,

    CraftBuildingChangeSettings,

    CraftBuildingTakeMoney,

    RepairBuildingChangeSettings,

    RepairBuildingTakeMoney,

    ActionBuildingChangeSettings,

    HarvestStart,

    HarvestCancel,

    TakeSilver,

    ActionOnBuildingStart,

    ActionOnBuildingCancel,

    InstallResourceStart,

    InstallResourceCancel,

    InstallSilver,

    BuildingFillNutrition,

    BuildingChangeRenovationState,

    BuildingBuySkin,

    BuildingClaim,

    BuildingGiveup,

    BuildingNutritionSilverStorageDeposit,

    BuildingNutritionSilverStorageWithdraw,

    BuildingNutritionSilverRewardSet,

    ConstructionSiteCreate,

    PlaceableObjectPlace,

    PlaceableObjectPlaceCancel,

    PlaceableObjectPickup,

    FurnitureObjectUse,

    FarmableHarvest,

    FarmableFinishGrownItem,

    FarmableDestroy,

    FarmableGetProduct,

    FarmableFill,

    TearDownConstructionSite,

    AuctionCreateOffer,

    AuctionCreateRequest,

    AuctionGetOffers,

    AuctionGetRequests,

    AuctionBuyOffer,

    AuctionAbortAuction,

    AuctionModifyAuction,

    AuctionAbortOffer,

    AuctionAbortRequest,

    AuctionSellRequest,

    AuctionGetFinishedAuctions,

    AuctionGetFinishedAuctionsCount,

    AuctionFetchAuction,

    AuctionGetMyOpenOffers,

    AuctionGetMyOpenRequests,

    AuctionGetMyOpenAuctions,

    AuctionGetItemAverageStats,

    AuctionGetItemAverageValue,

    ContainerOpen,

    ContainerClose,

    ContainerManageSubContainer,

    Respawn,

    Suicide,

    JoinGuild,

    LeaveGuild,

    CreateGuild,

    InviteToGuild,

    DeclineGuildInvitation,

    KickFromGuild,

    InstantJoinGuild,

    DuellingChallengePlayer,

    DuellingAcceptChallenge,

    DuellingDenyChallenge,

    ChangeClusterTax,

    ClaimTerritory,

    GiveUpTerritory,

    ChangeTerritoryAccessRights,

    GetMonolithInfo,

    GetClaimInfo,

    GetAttackInfo,

    GetTerritorySeasonPoints,

    GetAttackSchedule,

    GetMatches,

    GetMatchDetails,

    JoinMatch,

    LeaveMatch,

    GetClusterInstanceInfoForStaticCluster,

    ChangeChatSettings,

    LogoutStart,

    LogoutCancel,

    ClaimOrbStart,

    ClaimOrbCancel,

    MatchLootChestOpeningStart,

    MatchLootChestOpeningCancel,

    DepositToGuildAccount,

    WithdrawalFromAccount,

    ChangeGuildPayUpkeepFlag,

    ChangeGuildTax,

    GetMyTerritories,

    MorganaCommand,

    GetServerInfo,

    SubscribeToCluster,

    AnswerMercenaryInvitation,

    GetCharacterEquipment,

    GetCharacterSteamAchievements,

    GetCharacterStats,

    GetKillHistoryDetails,

    LearnMasteryLevel,

    ReSpecAchievement,

    ChangeAvatar,

    GetRankings,

    GetRank,

    GetGvgSeasonRankings,

    GetGvgSeasonRank,

    GetGvgSeasonHistoryRankings,

    GetGvgSeasonGuildMemberHistory,

    KickFromGvGMatch,

    GetCrystalLeagueDailySeasonPoints,

    GetChestLogs,

    GetAccessRightLogs,

    GetGuildAccountLogs,

    GetGuildAccountLogsLargeAmount,

    InviteToPlayerTrade,

    PlayerTradeCancel,

    PlayerTradeInvitationAccept,

    PlayerTradeAddItem,

    PlayerTradeRemoveItem,

    PlayerTradeAcceptTrade,

    PlayerTradeSetSilverOrGold,

    SendMiniMapPing,

    Stuck,

    BuyRealEstate,

    ClaimRealEstate,

    GiveUpRealEstate,

    ChangeRealEstateOutline,

    GetMailInfos,

    GetMailCount,

    ReadMail,

    SendNewMail,

    DeleteMail,

    MarkMailUnread,

    ClaimAttachmentFromMail,

    ApplyToGuild,

    AnswerGuildApplication,

    RequestGuildFinderFilteredList,

    UpdateGuildRecruitmentInfo,

    RequestGuildRecruitmentInfo,

    RequestGuildFinderNameSearch,

    RequestGuildFinderRecommendedList,

    RegisterChatPeer,

    SendChatMessage,

    SendModeratorMessage,

    JoinChatChannel,

    LeaveChatChannel,

    SendWhisperMessage,

    Say,

    PlayEmote,

    StopEmote,

    GetClusterMapInfo,

    AccessRightsChangeSettings,

    Mount,

    MountCancel,

    BuyJourney,

    SetSaleStatusForEstate,

    ResolveGuildOrPlayerName,

    GetRespawnInfos,

    MakeHome,

    LeaveHome,

    ResurrectionReply,

    AllianceCreate,

    AllianceDisband,

    AllianceGetMemberInfos,

    AllianceInvite,

    AllianceAnswerInvitation,

    AllianceCancelInvitation,

    AllianceKickGuild,

    AllianceLeave,

    AllianceChangeGoldPaymentFlag,

    AllianceGetDetailInfo,

    GetIslandInfos,

    BuyMyIsland,

    BuyGuildIsland,

    UpgradeMyIsland,

    UpgradeGuildIsland,

    TerritoryFillNutrition,

    TeleportBack,

    PartyInvitePlayer,

    PartyRequestJoin,

    PartyAnswerInvitation,

    PartyAnswerJoinRequest,

    PartyLeave,

    PartyKickPlayer,

    PartyMakeLeader,

    PartyChangeLootSetting,

    PartyMarkObject,

    PartySetRole,

    SetGuildCodex,

    ExitEnterStart,

    ExitEnterCancel,

    QuestGiverRequest,

    GoldMarketGetBuyOffer,

    GoldMarketGetBuyOfferFromSilver,

    GoldMarketGetSellOffer,

    GoldMarketGetSellOfferFromSilver,

    GoldMarketBuyGold,

    GoldMarketSellGold,

    GoldMarketCreateSellOrder,

    GoldMarketCreateBuyOrder,

    GoldMarketGetInfos,

    GoldMarketCancelOrder,

    GoldMarketGetAverageInfo,

    TreasureChestUsingStart,

    TreasureChestUsingCancel,

    UseLootChest,

    UseShrine,

    UseHellgateShrine,

    GetSiegeBannerInfo,

    LaborerStartJob,

    LaborerTakeJobLoot,

    LaborerDismiss,

    LaborerMove,

    LaborerBuyItem,

    LaborerUpgrade,

    BuyPremium,

    RealEstateGetAuctionData,

    RealEstateBidOnAuction,

    FriendInvite,

    FriendAnswerInvitation,

    FriendCancelnvitation,

    FriendRemove,

    InventoryStack,

    InventoryReorder,

    InventoryDropAll,

    InventoryAddToStacks,

    EquipmentItemChangeSpell,

    ExpeditionRegister,

    ExpeditionRegisterCancel,

    JoinExpedition,

    DeclineExpeditionInvitation,

    VoteStart,

    VoteDoVote,

    RatingDoRate,

    EnteringExpeditionStart,

    EnteringExpeditionCancel,

    ActivateExpeditionCheckPoint,

    ArenaRegister,

    ArenaAddInvite,

    ArenaRegisterCancel,

    ArenaLeave,

    JoinArenaMatch,

    DeclineArenaInvitation,

    EnteringArenaStart,

    EnteringArenaCancel,

    ArenaCustomMatch,

    UpdateCharacterStatement,

    BoostFarmable,

    GetStrikeHistory,

    UseFunction,

    UsePortalEntrance,

    ResetPortalBinding,

    QueryPortalBinding,

    ClaimPaymentTransaction,

    ChangeUseFlag,

    ClientPerformanceStats,

    ExtendedHardwareStats,

    ClientLowMemoryWarning,

    TerritoryClaimStart,

    TerritoryClaimCancel,

    DeliverCarriableObjectStart,

    DeliverCarriableObjectCancel,

    TerritoryUpgradeWithPowerCrystal,

    RequestAppStoreProducts,

    VerifyProductPurchase,

    QueryGuildPlayerStats,

    QueryAllianceGuildStats,

    TrackAchievements,

    SetAchievementsAutoLearn,

    DepositItemToGuildCurrency,

    WithdrawalItemFromGuildCurrency,

    AuctionSellSpecificItemRequest,

    FishingStart,

    FishingCasting,

    FishingCast,

    FishingCatch,

    FishingPull,

    FishingGiveLine,

    FishingFinish,

    FishingCancel,

    CreateGuildAccessTag,

    DeleteGuildAccessTag,

    RenameGuildAccessTag,

    FlagGuildAccessTagGuildPermission,

    AssignGuildAccessTag,

    RemoveGuildAccessTagFromPlayer,

    ModifyGuildAccessTagEditors,

    RequestPublicAccessTags,

    ChangeAccessTagPublicFlag,

    UpdateGuildAccessTag,

    SteamStartMicrotransaction,

    SteamFinishMicrotransaction,

    SteamIdHasActiveAccount,

    CheckEmailAccountState,

    LinkAccountToSteamId,

    InAppConfirmPaymentGooglePlay,

    InAppConfirmPaymentAppleAppStore,

    InAppPurchaseRequest,

    InAppPurchaseFailed,

    CharacterSubscriptionInfo,

    AccountSubscriptionInfo,

    BuyGvgSeasonBooster,

    ChangeFlaggingPrepare,

    OverCharge,

    OverChargeEnd,

    RequestTrusted,

    ChangeGuildLogo,

    PartyFinderRegisterForUpdates,

    PartyFinderUnregisterForUpdates,

    PartyFinderEnlistNewPartySearch,

    PartyFinderDeletePartySearch,

    PartyFinderChangePartySearch,

    PartyFinderChangeRole,

    PartyFinderApplyForGroup,

    PartyFinderAcceptOrDeclineApplyForGroup,

    PartyFinderGetEquipmentSnapshot,

    PartyFinderRegisterApplicants,

    PartyFinderUnregisterApplicants,

    PartyFinderFulltextSearch,

    PartyFinderRequestEquipmentSnapshot,

    GetPersonalSeasonTrackerData,

    GetPersonalSeasonPastRewardData,

    UseConsumableFromInventory,

    ClaimPersonalSeasonReward,

    EasyAntiCheatMessageToServer,

    XignCodeMessageToServer,

    BattlEyeMessageToServer,

    SetNextTutorialState,

    AddPlayerToMuteList,

    RemovePlayerFromMuteList,

    ProductShopUserEvent,

    GetVanityUnlocks,

    BuyVanityUnlocks,

    GetMountSkins,

    SetMountSkin,

    SetWardrobe,

    ChangeCustomization,

    ChangePlayerIslandData,

    GetGuildChallengePoints,

    SmartQueueJoin,

    SmartQueueLeave,

    SmartQueueSelectSpawnCluster,

    UpgradeHideout,

    InitHideoutAttackStart,

    InitHideoutAttackCancel,

    HideoutFillNutrition,

    HideoutGetInfo,

    HideoutGetOwnerInfo,

    HideoutSetTribute,

    HideoutUpgradeWithPowerCrystal,

    HideoutDeclareHQ,

    HideoutUndeclareHQ,

    HideoutGetHQRequirements,

    HideoutBoost,

    HideoutBoostConstruction,

    OpenWorldAttackScheduleStart,

    OpenWorldAttackScheduleCancel,

    OpenWorldAttackConquerStart,

    OpenWorldAttackConquerCancel,

    GetOpenWorldAttackDetails,

    GetNextOpenWorldAttackScheduleTime,

    RecoverVaultFromHideout,

    GetGuildEnergyDrainInfo,

    ChannelingUpdate,

    UseCorruptedShrine,

    RequestEstimatedMarketValue,

    LogFeedback,

    GetInfamyInfo,

    GetPartySmartClusterQueuePriority,

    SetPartySmartClusterQueuePriority,

    ClientAntiAutoClickerInfo,

    ClientBotPatternDetectionInfo,

    ClientAntiGatherClickerInfo,

    LoadoutCreate,

    LoadoutRead,

    LoadoutReadHeaders,

    LoadoutUpdate,

    LoadoutDelete,

    LoadoutOrderUpdate,

    LoadoutEquip,

    BatchUseItemCancel,

    EnlistFactionWarfare,

    GetFactionWarfareWeeklyReport,

    ClaimFactionWarfareWeeklyReport,

    GetFactionWarfareCampaignData,

    ClaimFactionWarfareItemReward,

    SendMemoryConsumption,

    PickupCarriableObjectStart,

    PickupCarriableObjectCancel,

    SetSavingChestLogsFlag,

    GetSavingChestLogsFlag,

    RegisterGuestAccount,

    ResendGuestAccountVerificationEmail,

    DoSimpleActionStart,

    DoSimpleActionCancel,

    GetGvgSeasonContributionByActivity,

    GetGvgSeasonContributionByCrystalLeague,

    GetGuildMightCategoryContribution,

    GetGuildMightCategoryOverview,

    GetPvpChallengeData,

    ClaimPvpChallengeWeeklyReward,

    GetPersonalMightStats,

    AuctionGetLoadoutOffers,

    AuctionBuyLoadoutOffer,

    AccountDeletionRequest,

    AccountReactivationRequest,

    GetModerationEscalationDefiniton,

    EventBasedPopupAddSeen,

    GetItemKillHistory,

    GetVanityConsumables,

    EquipKillEmote,

    ChangeKillEmotePlayOnKnockdownSetting,

    BuyVanityConsumableCharges,

    ReclaimVanityItem,

    GetArenaRankings,

    GetCrystalLeagueStatistics,

    SendOptionsLog,

    SendControlsOptionsLog,

    MistsUseImmediateReturnExit,

    MistsUseStaticEntrance,

    MistsUseCityRoadsEntrance,

    ChangeNewGuildMemberMail,

    GetNewGuildMemberMail,

    ChangeGuildFactionAllegiance,

    GetGuildFactionAllegiance,

    GuildBannerChange,

    GuildGetOptionalStats,

    GuildSetOptionalStats,

    GetPlayerInfoForStalk,

    PayGoldForCharacterTypeChange,

    QuickSellAuctionQueryAction,

    QuickSellAuctionSellAction,

    FcmTokenToServer,

    ApnsTokenToServer,

    DeathRecap,

    AuctionFetchFinishedAuctions,

    AbortAuctionFetchFinishedAuctions,

    RequestLegendaryEvenHistory,

    PartyAnswerStartHuntRequest,

    HuntAbort,

    UseFindTrackSpellFromItemPrepare,

    InteractWithTrackStart,

    InteractWithTrackCancel,

    TerritoryRaidStart,

    TerritoryRaidCancel,

    TerritoryClaimRaidedRawEnergyCrystalResult,

    GvGSeasonPlayerGuildParticipationDetails,

    DailyMightBonus,

    ClaimDailyMightBonus,

    GetFortificationGroupInfo,

    UpgradeFortificationGroup,

    CancelUpgradeFortificationGroup,

    DowngradeFortificationGroup,

    GetClusterActivityChestEstimates,

    PartyReadyCheckBegin,

    PartyReadyCheckUpdate,

    ClaimAlbionJournalReward,

    TrackAlbionJournalAchievements,

    RequestOutlandsTeleportationUsage,
}
