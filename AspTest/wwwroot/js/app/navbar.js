$(".nav a").on("click", function(){
   $(".nav").find(".active").removeClass("active");
   $(this).parent().addClass("active");
   //$("div.container#contents").find("div.container").hide();
   $("div.container#contents").find("div.container").css('display', 'none');
   //console.log($(this).attr('id'));
   //$("div.container#" + $(this).attr('id')).load("js/app/components/" + $(this).attr('id') + ".html").show();
   $("div.container#" + $(this).attr('id')).css('display', 'block');
   //console.log("done");
});