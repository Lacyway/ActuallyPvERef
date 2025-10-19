using SPTarkov.DI.Annotations;
using SPTarkov.Server.Core.DI;
using SPTarkov.Server.Core.Models.Common;
using SPTarkov.Server.Core.Models.Eft.Common.Tables;
using SPTarkov.Server.Core.Models.Spt.Mod;
using SPTarkov.Server.Core.Models.Utils;
using SPTarkov.Server.Core.Servers;
using SPTarkov.Server.Core.Services;

namespace ActuallyPvERef;

public record ModMetadata : AbstractModMetadata
{
    public override string ModGuid { get; init; } = "com.lacyway.apr";
    public override string Name { get; init; } = "ActuallyPvERef";
    public override string Author { get; init; } = "Lacyway";
    public override List<string>? Contributors { get; init; }
    public override SemanticVersioning.Version Version { get; init; } = new("1.0.0");
    public override SemanticVersioning.Range SptVersion { get; init; } = new("~4.0.0");
    public override List<string>? Incompatibilities { get; init; }
    public override Dictionary<string, SemanticVersioning.Range>? ModDependencies { get; init; }
    public override string? Url { get; init; }
    public override bool? IsBundleMod { get; init; }
    public override string? License { get; init; } = "MIT";
}

[Injectable(TypePriority = OnLoadOrder.PostDBModLoader + 5656)]
public class ActuallyPvERef(ISptLogger<ActuallyPvERef> logger,
    DatabaseService databaseService, DatabaseServer databaseServer) : IOnLoad
{
    public Task OnLoad()
    {
        EditQuests();
        logger.Success("ActuallyPvERef database update completed!");

        return Task.CompletedTask;
    }

    private void EditQuests()
    {
        MongoId[] refQuests = [
            new("68341eb25619c8e2a9031501"),
            new("68341f6fe2e7ef70a3060a0a"),
            new("6834202a186efa3c5b07f9a2"),
            new("683421515619c8e2a9031511"),
            new("68342265a8d674b5740b31f0"),
            new("68342446a8d674b5740b31fc")
        ];

        var quests = databaseService.GetQuests();
        var globals = databaseServer.GetTables().Locales.Global;

        var part1 = quests[refQuests[0]];
        part1.Conditions.AvailableForFinish.Clear();
        part1.Conditions.AvailableForFinish.Add(new QuestCondition()
        {
            Id = new("68341eb25619c8e2a9031504"),
            ConditionType = "CounterCreator",
            DynamicLocale = false,
            Type = "Elimination",
            Value = 20,
            Counter = new()
            {
                Conditions =
                [
                    new()
                    {
                        ConditionType = "Kills",
                        CompareMethod = ">=",
                        Distance = new()
                        {
                            CompareMethod = ">="
                        },
                        Id = new("67ee87fa75a5d18861fe8f88"),
                        Target = new(null, "Savage"),
                        Value = 1
                    }
                ]
            }
        });

        var part2 = quests[refQuests[1]];
        part2.Conditions.AvailableForFinish.Clear();
        part2.Conditions.AvailableForFinish.Add(new QuestCondition()
        {
            Id = new("68341f6fe2e7ef70a3060a0d"),
            ConditionType = "CounterCreator",
            DynamicLocale = false,
            Type = "Elimination",
            Value = 20,
            Counter = new()
            {
                Conditions =
                [
                    new()
                    {
                        ConditionType = "Kills",
                        CompareMethod = ">=",
                        Distance = new()
                        {
                            CompareMethod = ">="
                        },
                        Id = new("655e483da3ee7d4c56241e17"),
                        Target = new(null, "AnyPmc"),
                        Value = 1
                    }
                ]
            }
        });

        var part3 = quests[refQuests[2]];
        part3.Conditions.AvailableForFinish.Clear();
        part3.Conditions.AvailableForFinish.Add(new QuestCondition()
        {
            Id = new("662bb201589b7f21d7ab98fa"),
            ConditionType = "CounterCreator",
            DynamicLocale = false,
            Type = "Elimination",
            Value = 10,
            Counter = new()
            {
                Conditions =
                [
                    new()
                    {
                        ConditionType = "Kills",
                        CompareMethod = ">=",
                        Distance = new()
                        {
                            CompareMethod = ">="
                        },
                        Id = new("68ebbdf496bacde419279d25"),
                        Target = new(null, "Usec"),
                        Value = 1
                    }
                ]
            }
        });
        part3.Conditions.AvailableForFinish.Add(new QuestCondition()
        {
            Id = new("67ebc19b79b4cd1899cb20f7"),
            ConditionType = "CounterCreator",
            DynamicLocale = false,
            Type = "Elimination",
            Value = 10,
            Counter = new()
            {
                Conditions =
                [
                    new()
                    {
                        ConditionType = "Kills",
                        CompareMethod = ">=",
                        Distance = new()
                        {
                            CompareMethod = ">="
                        },
                        Id = new("67ebc19b79b4cd1899cb20f7"),
                        Target = new(null, "Bear"),
                        Value = 1
                    }
                ]
            }
        });

        var part4 = quests[refQuests[3]];
        part4.Conditions.AvailableForFinish.Clear();
        part4.Conditions.AvailableForFinish.Add(new QuestCondition()
        {
            Id = new("683421515619c8e2a9031514"),
            ConditionType = "HandoverItem",
            DynamicLocale = false,
            Value = 15,
            DogtagLevel = 40,
            OnlyFoundInRaid = true,
            MaxDurability = 100,
            MinDurability = 0,
            Target = new(
            [
                "59f32bb586f774757e1e8442", "6662e9aca7e0b43baa3d5f74", "6662e9cda7e0b43baa3d5f76",
                "675dc9d37ae1a8792107ca96", "675dcb0545b1a2d108011b2b", "684181208d035f60230f63f9",
                "684180bc51bf8645f7067bc8"
            ], null)
        });
        part4.Conditions.AvailableForFinish.Add(new QuestCondition()
        {
            Id = new("683421515619c8e2a9031515"),
            ConditionType = "HandoverItem",
            DynamicLocale = false,
            Value = 15,
            DogtagLevel = 40,
            OnlyFoundInRaid = true,
            MaxDurability = 100,
            MinDurability = 0,
            Target = new(
            [
                "59f32bb586f774757e1e8442", "6662e9aca7e0b43baa3d5f74", "6662e9cda7e0b43baa3d5f76",
                "675dc9d37ae1a8792107ca96", "675dcb0545b1a2d108011b2b", "684181208d035f60230f63f9",
                "684180bc51bf8645f7067bc8"
            ], null)
        });

        var part5 = quests[refQuests[4]];
        part5.Conditions.AvailableForFinish.Clear();
        part5.Conditions.AvailableForFinish.Add(new QuestCondition()
        {
            Id = new("662bb2c053b4c3d95e2e0753"),
            ConditionType = "CounterCreator",
            DynamicLocale = false,
            Type = "Elimination",
            Value = 1,
            Counter = new()
            {
                Conditions =
                [
                    new()
                    {
                        ConditionType = "Kills",
                        CompareMethod = ">=",
                        Distance = new()
                        {
                            CompareMethod = ">="
                        },
                        Id = new("68ebc1df1075f80e50e79cdb"),
                        SavageRole = ["bossKnight"],
                        Target = new(null, "Savage"),
                        Value = 1,
                        ResetOnSessionEnd = true
                    }
                ]
            }
        });
        part5.Conditions.AvailableForFinish.Add(new QuestCondition()
        {
            Id = new("67e6b6e2727d4a1492fcfe1c"),
            ConditionType = "CounterCreator",
            DynamicLocale = false,
            Type = "Elimination",
            Value = 1,
            Counter = new()
            {
                Conditions =
                [
                    new()
                    {
                        ConditionType = "Kills",
                        CompareMethod = ">=",
                        Distance = new()
                        {
                            CompareMethod = ">="
                        },
                        Id = new("68ebc226ed17d544f9264fc8"),
                        SavageRole = ["followerBigPipe"],
                        Target = new(null, "Savage"),
                        Value = 1,
                        ResetOnSessionEnd = true
                    }
                ]
            }
        });
        part5.Conditions.AvailableForFinish.Add(new QuestCondition()
        {
            Id = new("68ebc2460d29c043fcbd49b9"),
            ConditionType = "CounterCreator",
            DynamicLocale = false,
            Type = "Elimination",
            Value = 1,
            Counter = new()
            {
                Conditions =
                [
                    new()
                    {
                        ConditionType = "Kills",
                        CompareMethod = ">=",
                        Distance = new()
                        {
                            CompareMethod = ">="
                        },
                        Id = new("68ebc2492a2f82eace148352"),
                        SavageRole = ["followerBirdEye"],
                        Target = new(null, "Savage"),
                        Value = 1,
                        ResetOnSessionEnd = true
                    }
                ]
            }
        });

        var part6 = quests[refQuests[5]];
        part6.Conditions.AvailableForFinish.Clear();
        part6.Conditions.AvailableForFinish.Add(new QuestCondition()
        {
            Id = new("68342446a8d674b5740b3200"),
            ConditionType = "CounterCreator",
            DynamicLocale = false,
            Type = "Elimination",
            Value = 1,
            Counter = new()
            {
                Conditions =
                [
                    new()
                    {
                        ConditionType = "Kills",
                        CompareMethod = ">=",
                        Distance = new()
                        {
                            CompareMethod = ">="
                        },
                        Id = new("663b9bde92a93ce2d8b0b835"),
                        SavageRole = ["bossPartisan"],
                        Target = new(null, "Savage"),
                        Value = 1,
                        ResetOnSessionEnd = true
                    }
                ]
            }
        });

        foreach ((string locale, var lazyLoadedValue) in globals)
        {
            lazyLoadedValue.AddTransformer(localeData =>
            {
                if (localeData is null)
                {
                    return localeData;
                }

                // part1
                localeData["68341eb25619c8e2a9031504"] = "Eliminate scavs on any location";
                // part2
                localeData["68341f6fe2e7ef70a3060a0d"] = "Eliminate PMCs on any location";
                // part3
                localeData["662bb201589b7f21d7ab98fa"] = "Eliminate USEC PMC operatives on any location";
                localeData["67ebc19b79b4cd1899cb20f7"] = "Eliminate BEAR PMC operatives on any location";
                // part4
                localeData["683421515619c8e2a9031514"] = "Hand over the found in raid BEAR PMC dogtag (Level 40+)";
                localeData["683421515619c8e2a9031515"] = "Hand over the found in raid USEC PMC dogtag (Level 40+)";
                // part5
                localeData["662bb2c053b4c3d95e2e0753"] = "Eliminate Knight in one raid";
                localeData["67e6b6e2727d4a1492fcfe1c"] = "Eliminate Big Pipe in one raid";
                localeData["68ebc2460d29c043fcbd49b9"] = "Eliminate Bird Eye in one raid";
                // part6
                localeData["68342446a8d674b5740b3200"] = "Eliminate Partisan in one raid without dying";

                return localeData;
            });
        }
    }
}
