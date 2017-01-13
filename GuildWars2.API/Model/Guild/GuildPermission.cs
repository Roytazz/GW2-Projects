using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2API.Model.Guild
{
    public class GuildPermission
    {
        [JsonProperty("id")]
        public GuildPermissionType ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public enum GuildPermissionType
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
