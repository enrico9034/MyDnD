﻿---
--- Generated by EmmyLua(https://github.com/EmmyLua)
--- Created by davide.gozzi.
--- DateTime: 9/27/2022 1:57 PM
---

function GetModificator(statValue)
    local partial = ( statValue - 10 ) / 2
    if partial > 0
    then
        return math.floor(math.abs(partial))
    else
        return -1 * math.ceil(math.abs(partial))
    end
    return
end

function GetTableEntryValueKey(table, entryKey)
    for key, value in pairs(table) do
        if type(value) == "table" then
            if value.Name == entryKey then
                return key, value
            end
        end
    end
end