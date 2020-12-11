$(document).ready(function (e)
{
   $("#ic_dangki").click(function()
   {
       alert("phong vo van");
       $("#FormDangKi").dialog(
       {
        show:{effect:"blind", duration:1000},
		hide:{effect:"explode", duration:1000},
		width:500, 
		height:"auto",
		resizable:false,
		modal:true,
		buttons:
		{
			 "Đăng kí":function(){$(this).dialog("close");},
			 "Trở về": function () { $(this).dialog("close"); }
		}
       });

   });
   $("#ic_dangnhap").click(function () {
       $("#FormDangNhap").dialog(
       {
           show: { effect: "blind", duration: 1000 },
           hide: { effect: "explode", duration: 1000 },
           width: 500,
           height: "auto",
           resizable: false,
           modal: true,
           buttons:
           {
               "Đăng nhập": function () { $(this).dialog("close"); },
               "Trở về": function () { $(this).dialog("close"); }
           }
       });
   });
})