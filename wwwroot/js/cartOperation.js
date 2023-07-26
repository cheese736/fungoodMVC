const cart = JSON.parse(localStorage.getItem("cart")) ?? []
const modal = document.querySelector('#shopping-cart')
const totalPrice = document.querySelector('#total')

if (!modal.innerHTML.trim() && localStorage.getItem('cartHtml')){
	modal.innerHTML = localStorage.getItem('cartHtml')
	totalPrice.innerHTML = `總共: ${totalCaculator()}元`
}

function updateCartQty() {
	const cartQtyPill = document.querySelector('#cart-qty')
	let cartQty = 0
	cart.forEach(e => {
		cartQty ++
	})
	cartQtyPill.innerHTML = cartQty
}


function addToCart(btn) {
	const foodId = Number(btn.dataset.id)
	const price = Number(btn.dataset.price)
	const spicy = (btn.dataset.spicy === "True") ? true : false
	const name = btn.dataset.name
	const newItem = {
		"Id": cart.length + 1,
		"FoodItem": foodId,
		"Table": null,
		"Name": name,
		"Price": price,
		"HasSpiciness": spicy,
		"Spiciness": null
	}

	cart.push(newItem)
	updateCartQty()
	
	// add new line to the modal
	let temp = '' 
	temp += `
	<tr data-item-id=${newItem.Id}>
		<td>${newItem.Name}</td>
		<td class="text-center">${newItem.Price}</td>
	`
	if (newItem.HasSpiciness) {
		temp += `
		<td class="p-2 ">
			<select class="form-select form-select-sm w-75 mx-auto" onchange="specifySpiciness(this)" data-item-id=${newItem.Id}>
			<option value=0>不辣</option>
			<option value=1>小辣</option>
			<option value=2>中辣</option>
			<option value=3>大辣</option>
			</select>
		</td>
		`
	}
	temp += `
	</tr>
	`
	modal.innerHTML += temp

	totalPrice.innerHTML = `總共:${totalCaculator()}`
	updateLocalStorage()
}

function clearCart() {
	localStorage.removeItem("cart")
	localStorage.removeItem("cartHtml")
	location.reload()
}

function specifySpiciness(option) {
	cart.forEach(i => {
		if (i.Id == Number(option.dataset.itemId)) {
			i.Spiciness = Number(option.value)
		}
	})
	for (let i=0; i < option.children.length; i++) {
		if (option.children[i].value === option.value) {
			option.children[i].setAttribute("selected","")
		} else {
			option.children[i].removeAttribute("selected")
		}
	}
	updateLocalStorage()
}

function updateLocalStorage() {
	const cartJSON = JSON.stringify(cart)
	const cartHtml = modal.innerHTML
	localStorage.setItem("cart",cartJSON)
	localStorage.setItem("cartHtml",cartHtml)
}

async function sendOrder() {
	if (cart.length === 0) {
		alert("還沒點餐唷")
		return
	} 
	const tableSelector = document.querySelector('#table-selector')
	if (!tableSelector.value) {
		alert("請選擇桌號")
		return
	}
	cart.forEach(i => {
		i.Table = Number(tableSelector.value)
		if (i.HasSpiciness && !i.Spiciness) {
			i.Spiciness = 0
		}
	})
	const url = window.location.href
	const token = document.querySelector('input[name="__RequestVerificationToken"]').getAttribute("value")
	const res = await fetch(url,{
		method : "POST",
		headers: {
			"RequestVerificationToken": token,
			"Content-Type": "application/json",
		},
		body: JSON.stringify(cart)
	})
	clearCart()
	location.reload()
}

function totalCaculator() {
	return cart.reduce((acc, current) => {
		return acc + current.Price
	},0)
}