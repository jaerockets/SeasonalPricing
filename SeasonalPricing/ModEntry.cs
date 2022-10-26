using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;
using StardewValley.Locations;

namespace SeasonalPricing
{
    /// <summary>The mod entry point.</summary>
    public class ModEntry : Mod
    {
        /// <inheritdoc/>
        public override void Entry(IModHelper helper)
        {
            helper.Events.Content.AssetRequested += this.OnAssetRequested;
        }

        /// <inheritdoc cref="IContentEvents.AssetRequested"/>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event data.</param>
        private void OnAssetRequested(object sender, AssetRequestedEventArgs e)
        {
            if (e.NameWithoutLocale.IsEquivalentTo("Data/ObjectInformation"))
            {
                e.Edit(asset =>
                {
                    this.Monitor.Log("lambda execute", LogLevel.Debug);
                    var data = asset.AsDictionary<int, string>().Data;
                    List<int> springCrops = new List<int> { 597, 190, 433, 248, 188, 250, 24, 192, 222, 400, 591, 271, 16, 18, 20, 22, 399, 257, 404, 296 };
                    switch (Game1.currentSeason)
                    {
                        case "spring":
                            this.Monitor.Log("spring", LogLevel.Debug);
                            foreach (int itemID in data.Keys.ToArray())
                            {
                                if (springCrops.Contains(itemID))
                                {
                                    string[] fields = data[itemID].Split('/');
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                    fields[1] = (int.Parse(fields[1]) / 2).ToString();
                                    data[itemID] = string.Join("/", fields);
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                }
                            }
                            break;
                    }
                });
            }


        }
    }
}