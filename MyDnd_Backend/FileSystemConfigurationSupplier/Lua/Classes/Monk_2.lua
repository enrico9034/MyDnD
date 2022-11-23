function CheckRequirements()
    return character.Stats.Level > 1
end


function Calculate()

    character.Class = function(previusClass)
        key,value = GetTableEntryValueKey(previusClass, "Monk")
        previusClass[key].Level = 2
        return previusClass
    end

    character.PowerSystem = function(previusPowerSystem)
        table.insert(previusPowerSystem,
        {
            Name = "Ki",
            Level = 1,
            UsablePoint = 4,
            PointPerRest = 4,
            Skills = {}
        })
        return previusPowerSystem
    end

    character:Ki("FurryOfBlows")
end
