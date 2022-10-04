
function Calculate()
	local DexterityModificator = GetModificator(character.Stats.Dexterity)
	return 10 + tonumber(DexterityModificator)
end
