function CheckRequirements()
	return true
end

function Calculate()
	DexterityModificator = character.Stats.Dexterity.Modifier
	return 10 + DexterityModificator
end
