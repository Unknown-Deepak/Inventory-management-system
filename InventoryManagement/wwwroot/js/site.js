// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.      , { mob: $(obj).val() }

/*$(window).on("load", function () {
	alert("1");
	$.post("/Purchage/CustomerDelail", function (data) {
		alert("2");
		console.log(data);
		debugger;
	})
})
<script>
	$(window).on("load", function () {
		debugger;
		$.post("/Purchage/CustomerDelail", function (data) {
			$.each(data, function (i, customer) {
				$("#MobileNo").append('<option>"' + customer + '"');				
			})
		})
	})
</script>

function AddProduct() {
	if ($("#div_order").css("display") == "none") {
		$("#div_order").css('display', 'block');
		$('#div_otherinfo').css('display', 'block');
	}
	var innerhtml ='<tr> <td class="productimgname"> <a class="product-img"> <img src="/assets/img/product/product7.jpg" alt="product"> </a> <select class="form-control" onchange="GetProductDetails(this)"> <option value="1">select Product</option> <option value="1">product1</option> <option value="1">product1</option> </select> </td> <td><input type="text" class="form-control" onkeyup="GetTotalPrice(this)"/> </td> <td>2000.00</td> <td>500.00</td> <td>0.00</td> <td>0.00</td> <td class="text-end">2000.00</td> <td class="text-end">2000.00</td> <td> <a class="delete-set"><img src="/assets/img/icons/delete.svg" alt="svg"></a> </td> </tr>'
	$("#tbl_Product tbody").append(innerhtml)
}
function GetProductDetails(obj) {
	var ProductId = $(obj).val();
	alert(ProductId);
}

/*function Add&SearchProduct(){
	var name = $("#CustomerName").val();
	var Mobile = +$("#CustomerMobile").val();
	$.post("Purchage/Customer")
}



function GetTotalPrice(obj) {

	var quentity = $(obj).val();
	alert(quentity);
}
*/