
function printContent(id) {
    var str = document.getElementById(id).innerHTML;
    newwin = window.open('', 'printwin', 'left=150,top=10,width=850,height=600,scrollbars=yes,resizable=yes')
    newwin.document.write('<HTML>\n<HEAD>\n')
    newwin.document.write('<TITLE>www.xyz.com</TITLE>\n')
    newwin.document.write('<style type = "text/css">\n')
    newwin.document.write('font-family: Arial; font-size:14px\n')
    newwin.document.write('</style>\n')
    newwin.document.write('<script>\n')
    newwin.document.write('function chkstate(){\n')
    newwin.document.write('if(document.readyState=="complete"){\n')
    newwin.document.write('window.close()\n')
    newwin.document.write('}\n')
    newwin.document.write('else{\n')
    newwin.document.write('setTimeout("chkstate()",2000)\n')
    newwin.document.write('}\n')
    newwin.document.write('}\n')
    newwin.document.write('function print_win(){\n')
    newwin.document.write('window.print();\n')
    newwin.document.write('chkstate();\n')
    newwin.document.write('}\n')
    newwin.document.write('<\/script>\n')
    newwin.document.write('</HEAD>\n')
    newwin.document.write('<BODY  onload="print_win()">\n')
    newwin.document.write(str)
    newwin.document.write('</BODY>\n')
    newwin.document.write('</HTML>\n')
    newwin.document.close()
}

function open_win(url_add) {
    // alert("testing...");
    var strFeatures = "toolbar=no,status=no,menubar=no,location=no"
    strFeatures = strFeatures + ",scrollbars=yes,resizable=yes,height=450,width=600"
    // ADDED THE LINE BELOW TO ORIGINAL EXAMPLE
    strFeatures = strFeatures + ",left=100,top=200"
    newWin = window.open(url_add, "Details", strFeatures);
    newWin.opener = top;
    //window.open(url_add,'_self','width=200,height=200,menubar=no,status=no,location=yes,toolbar=no,scrollbars=yes,resizable=no');
    //window.open(url_add,
    //window.open(url_add,'_parent',config='width=200,height=200,location=no');
    // return false;
}

