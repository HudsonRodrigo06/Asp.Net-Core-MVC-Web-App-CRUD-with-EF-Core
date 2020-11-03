$(function () {
	$("#loaderbody").addClass('hide');

	$(document).bind('ajaxStart', function () {
		$("#loaderbody").removeClass('hide');
	}).bind('ajaxStop', function () {
		$("#loaderbody").addClass('hide');
	});
});


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
					$.notify('Enviado com sucesso!', { globalPosition: 'top center', className : 'success' });
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
				$.notify('Deletado com sucesso!', { globalPosition: 'top center', className : 'success' });
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