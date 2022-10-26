using System;
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
                /*    e.Edit(asset =>
                    {
                        var data = asset.AsDictionary<int, string>().Data;

                        foreach (int itemID in data.Keys.ToArray()) 
                        {
                            string[] fields = data[itemID].Split('/'); //for each itemID, create an array indexed by '/',
                            fields[1] = (int.Parse(fields[1]) * 2).ToString(); //change value of field [1] to value of field [1] * 2 (doubles price of all items)
                            data[itemID] = string.Join("/", fields); //convert array back to string
                        }
                    }); */
                e.Edit(asset =>
                {
                    this.Monitor.Log("lambda execute", LogLevel.Debug);
                    var data = asset.AsDictionary<int, string>().Data;
                    switch (Game1.currentSeason)
                    {
                        case "spring":
                            this.Monitor.Log("spring", LogLevel.Debug);
                            break;
                    }
                    foreach (int itemID in data.Keys.ToArray())
                    {
                        string[] fields = data[itemID].Split('/');
                        if (fields[0] == "Daffodil")
                        {
                            this.Monitor.Log("Daffodil", LogLevel.Debug);
                            this.Monitor.Log($"{(int.Parse(fields[1]) * 2).ToString()}", LogLevel.Debug);
                            fields[1] = (int.Parse(fields[1]) * 2).ToString();
                            data[itemID] = string.Join("/", fields);
                            this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                        }
                    }
                });
            }


        }
    }
}