using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2APIPlaceHolder.Model.Guild
{
    public class Permission
    {
        [JsonProperty("id")]
        public GuildPermission ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public enum GuildPermission
    {
        ClaimableEditOptions,
        EditBGM,
        ActivatePlaceables,
        DepositItemsTrove,
        WithdrawItemsStash,
        WithdrawItemsTrove,
        EditAssemblyQueue,
        WithdrawCoinsStash,
        ActivateWorldEvent,
        PlaceArenaDecoration,
        DepositItemsStash,
        EditMonument,
        StartingRole,
        SpendFuel,
        TeamAdmin,
        EditRoles,
        Admin,
        WithdrawCoinsTrove,
        DepositCoinsTrove,
        PurchaseUpgrades,
        EditEmblem,
        ClaimableActivate,
        MissionControl,
        OpenPortal,
        SetGuildHall,
        DepositCoinsStash,
        PlaceDecoration,
        ClaimableSpend,
        EditMOTD,
        EditAnthem,
        DecorationAdmin,
        ClaimableClaim
    }
}
