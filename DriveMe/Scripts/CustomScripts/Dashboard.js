function openPopup(url) {
   
   
    $.get(url, function (data) {
      
        $('#content11').html(data);
        $('#myModal').css('width', '500px');
        $('#myModal').css('overflow-y', 'auto');
        $('#myModal').modal('show');
    });   

   
    //$.get(url, function (data) {
    //    var dialog = bootbox.dialog({
    //        message: data,
    //        closeButton: true,
    //        backdrop:true
    //    });
    //});   
}