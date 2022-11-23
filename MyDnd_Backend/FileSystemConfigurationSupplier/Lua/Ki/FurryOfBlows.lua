function CheckRequirements()
    return true
end

function Calculate()
    character.PowerSystem = function(previusPowerSystem)
        key, value = GetTableEntryValueKey(previusPowerSystem, "Ki")
        
        table.insert(previusPowerSystem[key].Skills,
            {
                Name = "Furry Of Blows",
                Description = "So many blows"
            })
        return previusPowerSystem
    end

end
