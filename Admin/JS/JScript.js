﻿function jScript() {


//===== Multiple select with dropdown =====//
	
	//$(".chzn-select").chosen(); 
	
	//===== Usual validation engine=====//

	$("#aspnetForm").validate();
	//===== ToTop =====//

	$().UItoTop({ easingType: 'easeOutQuart' });	
	//===== WYSIWYG editor =====//
	
	$('.wysiwyg').wysiwyg({
		iFrameClass: "wysiwyg-input",
		controls: {
			bold          : { visible : true },
			italic        : { visible : true },
			underline     : { visible : true },
			strikeThrough : { visible : false },
			
			justifyLeft   : { visible : true },
			justifyCenter : { visible : true },
			justifyRight  : { visible : true },
			justifyFull   : { visible : true },
			
			indent  : { visible : true },
			outdent : { visible : true },
			
			subscript   : { visible : false  },
			superscript : { visible : false },
			
			undo : { visible : true },
			redo : { visible : true },
			
			insertOrderedList    : { visible : true },
			insertUnorderedList  : { visible : true },
			insertHorizontalRule : { visible : false },

			h1: {
			visible: true,
			className: 'h1',
			command: ($.browser.msie || $.browser.safari) ? 'formatBlock' : 'heading',
			arguments: ($.browser.msie || $.browser.safari) ? '<h1>' : 'h1',
			tags: ['h1'],
			tooltip: 'Header 1'
			},
			h2: {
			visible: true,
			className: 'h2',
			command: ($.browser.msie || $.browser.safari) ? 'formatBlock' : 'heading',
			arguments: ($.browser.msie || $.browser.safari) ? '<h2>' : 'h2',
			tags: ['h2'],
			tooltip: 'Header 2'
			},
			h3: {
			visible: true,
			className: 'h3',
			command: ($.browser.msie || $.browser.safari) ? 'formatBlock' : 'heading',
			arguments: ($.browser.msie || $.browser.safari) ? '<h3>' : 'h3',
			tags: ['h3'],
			tooltip: 'Header 3'
			},
			h4: {
			visible: true,
			className: 'h4',
			command: ($.browser.msie || $.browser.safari) ? 'formatBlock' : 'heading',
			arguments: ($.browser.msie || $.browser.safari) ? '<h4>' : 'h4',
			tags: ['h4'],
			tooltip: 'Header 4'
			},
			h5: {
			visible: true,
			className: 'h5',
			command: ($.browser.msie || $.browser.safari) ? 'formatBlock' : 'heading',
			arguments: ($.browser.msie || $.browser.safari) ? '<h5>' : 'h5',
			tags: ['h5'],
			tooltip: 'Header 5'
			},
			h6: {
			visible: true,
			className: 'h6',
			command: ($.browser.msie || $.browser.safari) ? 'formatBlock' : 'heading',
			arguments: ($.browser.msie || $.browser.safari) ? '<h6>' : 'h6',
			tags: ['h6'],
			tooltip: 'Header 6'
			},
			
			cut   : { visible : true },
			copy  : { visible : true },
			paste : { visible : true },
			html  : { visible: true },
			increaseFontSize : { visible : false },
			decreaseFontSize : { visible : false }
			},
		events: {
			click: function(event) {
				if ($("#click-inform:checked").length > 0) {
					event.preventDefault();
					alert("You have clicked jWysiwyg content!");
				}
			}
		}
	});
	
	//$('.wysiwyg').wysiwyg("insertHtml", "Sample code");


	//===== Dynamic data table =====//
	 oTable = $('#Column0').dataTable({
		"bJQueryUI": true,
		"sPaginationType": "full_numbers",
		"sDom": '<""f>t<"F"lp>'
	});
    oTable = $('#Column1').dataTable({
		"bJQueryUI": true,
		"sPaginationType": "full_numbers",
		"sDom": '<""f>t<"F"lp>',
		"aoColumnDefs": [ { "bSortable": false, "aTargets": [ 1 ] }]
	});
	oTable = $('#Column2').dataTable({
		"bJQueryUI": true,
		"sPaginationType": "full_numbers",
		"sDom": '<""f>t<"F"lp>',
		"aoColumnDefs": [ { "bSortable": false, "aTargets": [ 2 ] }]
	});
	oTable = $('#Column3').dataTable({
		"bJQueryUI": true,
		"sPaginationType": "full_numbers",
		"sDom": '<""f>t<"F"lp>',
		"aoColumnDefs": [ { "bSortable": false, "aTargets": [ 3 ] }]
	});
	oTable = $('#Column4').dataTable({
		"bJQueryUI": true,
		"sPaginationType": "full_numbers",
		"sDom": '<""f>t<"F"lp>',
		"aoColumnDefs": [ { "bSortable": false, "aTargets": [ 4 ] }]
	});
	oTable = $('#Column5').dataTable({
		"bJQueryUI": true,
		"sPaginationType": "full_numbers",
		"sDom": '<""f>t<"F"lp>',
		"aoColumnDefs": [ { "bSortable": false, "aTargets": [ 5 ] }]
	});
	oTable = $('#Column6').dataTable({
		"bJQueryUI": true,
		"sPaginationType": "full_numbers",
		"sDom": '<""f>t<"F"lp>',
		"aoColumnDefs": [ { "bSortable": false, "aTargets": [ 6 ] }]
	});
	oTable = $('#Column7').dataTable({
		"bJQueryUI": true,
		"sPaginationType": "full_numbers",
		"sDom": '<""f>t<"F"lp>',
		"aoColumnDefs": [ { "bSortable": false, "aTargets": [ 7 ] }]
	});
	oTable = $('#Column8').dataTable({
		"bJQueryUI": true,
		"sPaginationType": "full_numbers",
		"sDom": '<""f>t<"F"lp>',
		"aoColumnDefs": [ { "bSortable": false, "aTargets": [ 8 ] }]
	});
	oTable = $('#Column1_2').dataTable({
		"bJQueryUI": true,
		"sPaginationType": "full_numbers",
		"sDom": '<""f>t<"F"lp>',
		"aoColumnDefs": [ { "bSortable": false, "aTargets": [ 1,2 ] }]
	});
		oTable = $('#Column2_3').dataTable({
		"bJQueryUI": true,
		"sPaginationType": "full_numbers",
		"sDom": '<""f>t<"F"lp>',
		"aoColumnDefs": [ { "bSortable": false, "aTargets": [ 2,3 ] }]
	});
	
	 oTable = $('#Column3_4').dataTable({
		"bJQueryUI": true,
		"sPaginationType": "full_numbers",
		"sDom": '<""f>t<"F"lp>',
		"aoColumnDefs": [ { "bSortable": false, "aTargets": [ 3,4 ] }]
	});
	
	 
	 
	//===== Form elements styling =====//
	
$("select, input:checkbox, input:radio, input:file").uniform();
	
	
	//===== Form validation engine =====//

	$("#valid").validationEngine();
	

	//===== Datepickers =====//

	$( ".datepicker" ).datepicker({ 
		defaultDate: +7,
		autoSize: true,
		appendText: '(dd-mm-yyyy)',
		dateFormat: 'dd-mm-yy'
	});	

	$( ".datepickerInline" ).datepicker({ 
		defaultDate: +7,
		autoSize: true,
		appendText: '(dd-mm-yyyy)',
		dateFormat: 'dd-mm-yy',
		numberOfMonths: 1
	});	



//===== Left navigation submenu animation =====//	
		
	$("ul.sub li a").hover(function() {
	$(this).stop().animate({ color: "#3a6fa5" }, 400);
	},function() {
	$(this).stop().animate({ color: "#494949" }, 400);
	});
	
//===== User nav dropdown =====//		

	$('.dd').hover(function () {
		$('ul.menu_body').slideToggle(200);
	});
	
	$(document).bind('click', function(e) {
	var $clicked = $(e.target);
	if (! $clicked.parents().hasClass("dd"))
		$("ul.menu_body").slideUp(200);
	});
	
    $('.dd2').hover(function () {
		$('ul.menu_body2').slideToggle(200);
	});
	
	$(document).bind('click', function(e) {
	var $clicked = $(e.target);
	if (! $clicked.parents().hasClass("dd2"))
		$("ul.menu_body2").slideUp(200);
	});
	
	
	//===== Collapsible elements management =====//
	
	$('.exp').collapsible({
		defaultOpen: 'current',
		cookieName: 'navAct',
		cssOpen: 'active corner',
		cssClose: 'inactive',
		speed: 300
	});

	$('.opened').collapsible({
		defaultOpen: 'opened,toggleOpened',
		cssOpen: 'inactive',
		cssClose: 'normal',
		speed: 200
	});

	$('.closed').collapsible({
		defaultOpen: '',
		cssOpen: 'inactive',
		cssClose: 'normal',
		speed: 200
	});
}

