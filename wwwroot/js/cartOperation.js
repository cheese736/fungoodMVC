const cart = JSON.parse(localStorage.getItem("cart")) ?? []
function updateCartQty(cart) {
	const cartQtyPill = document.querySelector('#cart-qty')
	let cartQty = 0
	cart.forEach(e => {
		cartQty += e.quantity
	})
	cartQtyPill.innerHTML = cartQty
}

function addToCart(btn) {
	const foodId = Number(btn.dataset.id)
	const price = Number(btn.dataset.price)
	const name = btn.dataset.name
	if (!cart.some(e => e.foodId === foodId)) {
		cart.push({
			"foodId": foodId,
			"name": name,
			"quantity": 1,
			"price": price
		})
	} else {
		cart.forEach(e => {
			if (e.foodId === foodId) {
				e.quantity ++
			}
		})
	}
	updateCartQty(cart)
	const cartJSON = JSON.stringify(cart)
	localStorage.setItem("cart",cartJSON)
}

function renderCart() {
	const modal = document.querySelector('#shopping-cart')
	const totalPrice = document.querySelector('#total')
	const data = JSON.parse(localStorage.getItem('cart'))
	let total = 0
	let temp = ""
	data.forEach(item => {
		temp += `
		<tr>
			<td>${item.name}</td>
			<td class="text-center">${item.quantity}</td>
			<td class="text-center">${item.price}</td>
		</tr>
		`
		total += item.price * item.quantity
	})
	modal.innerHTML = temp
	totalPrice.innerHTML = `總共:${total}`
}

function clearCart() {
	localStorage.removeItem("cart")
	location.reload()
}