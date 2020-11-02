
showInPopup = (url, title) => {

	$.ajax({
		type: "GET",
		url: url,
		success: (response) => {
			$('#form-modal .modal-body').html(response);
			$('#form-modal .modal-title').html(title);
			$('#form-modal').modal('show');
		}
	})

}

jQueryAjaxPostTest = async (url, obj) => {

	let config = {
		method: "POST",
		body: JSON.stringify(obj),
		headers: {
			"Content-Type": "application/json"
		}
	}

	let p = await fetch(url, config);

	HTTPClient.toggleLoading();

	return p;
}

jQueryAjaxPost = (form) => {

	try {

		$.ajax({
			type: "POST",
			url: form.action,
			data: new FormData(form),
			contentType: false,
			processData: false,
			success: (response) => {

				if (response.isValid) {
					// chama view all
					$('#view-all').html(response.html);

					//retira os dados do modal e esconde
					$('#form-modal .modal-body').html('');
					$('#form-modal .modal-title').html('');
					$('#form-modal').modal('hide');
				}
				else
					$('#form-modal .modal-body').html(response.html);

			},
			error: (err) => {
				console.log(err);
			}
		})



	} catch (e) {
		console.log(e);
	}


	//para prevenir submit evento do form
	return false;
}

jQueryAjaxDelete = (form) => {

	try {

		$.ajax({
			type: "POST",
			url: form.action,
			data: new FormData(form),
			contentType: false,
			processData: false,
			success: (response) => {

				// chama view all
				$('#view-all').html(response.html);
			},
			error: (err) => {
				console.log(err);
			}
		})

	} catch (e) {
		console.log(e);
	}


	//para prevenir submit evento do form
	return false;
}