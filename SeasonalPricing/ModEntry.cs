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
                    List<int> springCrops = new List<int> { 597, 190, 248, 188, 250, 24, 192, 222, 400, 591, 271, 16, 18, 20, 22, 399, 296 };
                    List<int> summerCrops = new List<int> { 258, 270, 304, 260, 254, 376, 264, 266, 268, 593, 421, 256, 262, 398, 396, 402, 259 };
                    List<int> fallCrops   = new List<int> { 300, 274, 284, 278, 282, 272, 595, 398, 276, 280, 410, 408, 406 };
                    List<int> winterCrops = new List<int> { 412, 414, 416, 418, 283 };
                    List<int> springsummerCrops = new List<int> { 433 };
                    List<int> summerfallCrops = new List<int> { 270, 421, 262 };
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
                                if (summerCrops.Contains(itemID))
                                {
                                    string[] fields = data[itemID].Split('/');
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                    fields[1] = (int.Parse(fields[1]) * 1.6).ToString();
                                    data[itemID] = string.Join("/", fields);
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                }
                                if (fallCrops.Contains(itemID))
                                {
                                    string[] fields = data[itemID].Split('/');
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                    fields[1] = (int.Parse(fields[1]) * 1.4).ToString();
                                    data[itemID] = string.Join("/", fields);
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                }
                                if (winterCrops.Contains(itemID))
                                {
                                    string[] fields = data[itemID].Split('/');
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                    fields[1] = (int.Parse(fields[1]) * 1.2).ToString();
                                    data[itemID] = string.Join("/", fields);
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                }
                                if (springsummerCrops.Contains(itemID))
                                {
                                    string[] fields = data[itemID].Split('/');
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                    fields[1] = (int.Parse(fields[1]) / 2).ToString();
                                    data[itemID] = string.Join("/", fields);
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                }
                                if (summerfallCrops.Contains(itemID))
                                {
                                    string[] fields = data[itemID].Split('/');
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                    fields[1] = (int.Parse(fields[1]) * 1.4).ToString();
                                    data[itemID] = string.Join("/", fields);
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                }
                            }
                            break;
                        case "summer":
                            this.Monitor.Log("summer", LogLevel.Debug);
                            foreach (int itemID in data.Keys.ToArray())
                            {
                                if (springCrops.Contains(itemID))
                                {
                                    string[] fields = data[itemID].Split('/');
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                    fields[1] = (int.Parse(fields[1]) * 1.2).ToString();
                                    data[itemID] = string.Join("/", fields);
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                }
                                if (summerCrops.Contains(itemID))
                                {
                                    string[] fields = data[itemID].Split('/');
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                    fields[1] = (int.Parse(fields[1]) / 2).ToString();
                                    data[itemID] = string.Join("/", fields);
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                }
                                if (fallCrops.Contains(itemID))
                                {
                                    string[] fields = data[itemID].Split('/');
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                    fields[1] = (int.Parse(fields[1]) * 1.6).ToString();
                                    data[itemID] = string.Join("/", fields);
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                }
                                if (winterCrops.Contains(itemID))
                                {
                                    string[] fields = data[itemID].Split('/');
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                    fields[1] = (int.Parse(fields[1]) * 1.4).ToString();
                                    data[itemID] = string.Join("/", fields);
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                }
                                if (springsummerCrops.Contains(itemID))
                                {
                                    string[] fields = data[itemID].Split('/');
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                    fields[1] = (int.Parse(fields[1]) / 2).ToString();
                                    data[itemID] = string.Join("/", fields);
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                }
                                if (summerfallCrops.Contains(itemID))
                                {
                                    string[] fields = data[itemID].Split('/');
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                    fields[1] = (int.Parse(fields[1]) / 2).ToString();
                                    data[itemID] = string.Join("/", fields);
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                }
                            }
                            break;
                        case "fall":
                            this.Monitor.Log("fall", LogLevel.Debug);
                            foreach (int itemID in data.Keys.ToArray())
                            {
                                if (springCrops.Contains(itemID))
                                {
                                    string[] fields = data[itemID].Split('/');
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                    fields[1] = (int.Parse(fields[1]) * 1.4).ToString();
                                    data[itemID] = string.Join("/", fields);
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                }
                                if (summerCrops.Contains(itemID))
                                {
                                    string[] fields = data[itemID].Split('/');
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                    fields[1] = (int.Parse(fields[1]) * 1.2).ToString();
                                    data[itemID] = string.Join("/", fields);
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                }
                                if (fallCrops.Contains(itemID))
                                {
                                    string[] fields = data[itemID].Split('/');
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                    fields[1] = (int.Parse(fields[1]) / 2).ToString();
                                    data[itemID] = string.Join("/", fields);
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                }
                                if (winterCrops.Contains(itemID))
                                {
                                    string[] fields = data[itemID].Split('/');
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                    fields[1] = (int.Parse(fields[1]) * 1.6).ToString();
                                    data[itemID] = string.Join("/", fields);
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                }
                                if (springsummerCrops.Contains(itemID))
                                {
                                    string[] fields = data[itemID].Split('/');
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                    fields[1] = (int.Parse(fields[1]) * 1.2).ToString();
                                    data[itemID] = string.Join("/", fields);
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                }
                                if (summerfallCrops.Contains(itemID))
                                {
                                    string[] fields = data[itemID].Split('/');
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                    fields[1] = (int.Parse(fields[1]) / 2).ToString();
                                    data[itemID] = string.Join("/", fields);
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                }
                            }
                            break;
                        case "winter":
                            this.Monitor.Log("winter", LogLevel.Debug);
                            foreach (int itemID in data.Keys.ToArray())
                            {
                                if (springCrops.Contains(itemID))
                                {
                                    string[] fields = data[itemID].Split('/');
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                    fields[1] = (int.Parse(fields[1]) * 1.6).ToString();
                                    data[itemID] = string.Join("/", fields);
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                }
                                if (summerCrops.Contains(itemID))
                                {
                                    string[] fields = data[itemID].Split('/');
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                    fields[1] = (int.Parse(fields[1]) * 1.4).ToString();
                                    data[itemID] = string.Join("/", fields);
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                }
                                if (fallCrops.Contains(itemID))
                                {
                                    string[] fields = data[itemID].Split('/');
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                    fields[1] = (int.Parse(fields[1]) * 1.2).ToString();
                                    data[itemID] = string.Join("/", fields);
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                }
                                if (winterCrops.Contains(itemID))
                                {
                                    string[] fields = data[itemID].Split('/');
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                    fields[1] = (int.Parse(fields[1]) / 2).ToString();
                                    data[itemID] = string.Join("/", fields);
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                }
                                if (springsummerCrops.Contains(itemID))
                                {
                                    string[] fields = data[itemID].Split('/');
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                    fields[1] = (int.Parse(fields[1]) * 1.4).ToString();
                                    data[itemID] = string.Join("/", fields);
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                }
                                if (summerfallCrops.Contains(itemID))
                                {
                                    string[] fields = data[itemID].Split('/');
                                    this.Monitor.Log($"{data[itemID]}", LogLevel.Debug);
                                    fields[1] = (int.Parse(fields[1]) * 1.2).ToString();
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