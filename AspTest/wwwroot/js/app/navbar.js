$(".nav a").on("click", function(){
   $(".nav").find(".active").removeClass("active");
   $(this).parent().addClass("active");
   $(".container").find("#markedpost").load("js/app/components/markedpost.html");
});