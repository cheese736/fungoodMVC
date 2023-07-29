const helper = {
	formDataInspector: (form) => {
		for (var pair of form.entries()) {
            console.log(pair[0]+ ', ' + pair[1])
        }
	},

	formDataTypeConverter: (key, value) => {
		switch (key) {
			case "Id": return Number(value)
			case "FoodItemId": return Number(value)
			case "ShouldBeDelete": return Boolean(value)
			case "Spiciness": return Number(value)
			default: return value
		}
	}
}