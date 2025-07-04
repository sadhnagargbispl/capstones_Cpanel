/*--------------------------------------------------|
|---------------------------------------------------|
| Copyright (c) 2002-2003 Geir Landrö               |

| This script can be used freely as long as all     |
| copyright messages are intact.                    |
|                                                   |
| Updated: 20.3.2009 by Bharat Lakhani    
|                    |
|--------------------------------------------------*/

// Node object
//alert("D TREE");
var tootipwidth = 280;
var tootipBgColor = 'Black';
var tooltipfonttxt = 'color=#564300 size=2Px family=Verdana'
var tooltipfontlbl = 'color=White size=2Px family=Verdana'
var tooltiptdtxt = 'bgcolor=White'
var tooltiptdlbl = 'bgcolor=#564300'
function Node(id, pid, category, doj, UpgradeDate, name, nodename, upliner, sponsor, leftbv, rightbv, DirctLeftActive, DirectRightActive, url, title, target, icon, iconOpen, open, idstatus, Mobile,Isblock) {
	this.id = id;
	this.pid = pid;
	this.name = name;
	this.url = url;
	this.title = title;
	this.target = target;
	this.icon = icon;
	this.iconOpen = iconOpen;
	this._io = open || false;
	this._is = false; // if this node is selected or not
	this._ls = false; // is this node is the last sibling
	this._hc = false; // if this node have children or not
	this._ai = 0;
	this._p;            // the parent node of this node
	this._children = 0; // Number of children this nodes have
	this._isLeft = false; // Is this node is a very left child
	this._isRight = false; // Is this node is a very right child
	this._isOnly = false;  // Is this node is the only child for its parent
	this._nodeIndex = 0; // the index of this node in the childs array of its parent
	this.upliner = upliner;
	this.sponsor = sponsor;
	this.doj = doj;
	this.UpgradeDate = UpgradeDate;
	this.category = category;
	this.leftbv = leftbv;
	this.rightbv = rightbv;
	this.DirctLeftActive = DirctLeftActive;
	this.DirectRightActive = DirectRightActive;
	this.nodename = nodename;
	this.idstatus = idstatus;
	this.Mobile = Mobile;
	this.Isblock = Isblock;
	
	
};

// Tree object
function dTree(objName, topicon) {
	this.config = {
		target			: null,
		folderLinks		: true,
		useSelection	: true,
		useCookies		: true,
		useLines		: true,
		useIcons		: true,
		useStatusText	: false,
		closeSameLevel	: false,
		inOrder			: false
	}
	this.icon = {
	//root			: 'img/base.jpg',
	    root            : topicon,
		folder			: 'img/referalnew.gif',
		folderOpen		: 'img/referalnew.gif',
		node			: topicon, //'img/referalnew.gif',
		empty			: 'img/empty.gif',
		line			: 'img/line.gif',
		join			: 'img/join.gif',
		joinBottom		: 'img/joinbottom.gif',
		plus			: 'img/plus.gif',
		plusBottom		: 'img/plusbottom.gif',
		minus			: 'img/minus.gif',
		minusBottom		: 'img/minusbottom.gif',
		nlPlus			: 'img/nolines_plus.gif',
		nlMinus			: 'img/nolines_minus.gif',				middleLine		: 'img/myline2.gif',				leftLine		: 'img/myline2.gif',				smallLine		: 'img/smallLine.gif',				rightLine		: 'img/myline2.gif'
	};
	this.obj = objName;
	this.aNodes = [];
	this.aIndent = [];
	this.root = new Node(-1);
	this.selectedNode = null;
	this.selectedFound = false;
	this.completed = false;
};

// Adds a new node to the node array
dTree.prototype.add = function(id, pid, category, doj, UpgradeDate, name, nodename, upliner, sponsor, leftbv, rightbv, DirctLeftActive, DirectRightActive, url, title, target, icon, iconOpen, open, idstatus, Mobile,Isblock) {
this.aNodes[this.aNodes.length] = new Node(id, pid, category, doj, UpgradeDate, name, nodename, upliner, sponsor, leftbv, rightbv, DirctLeftActive, DirectRightActive, url, title, target, icon, iconOpen, open, idstatus, Mobile,Isblock);
};

// Open/close all nodes
dTree.prototype.openAll = function() {
	this.oAll(true);
};
dTree.prototype.closeAll = function() {
	this.oAll(false);
};

// Outputs the tree to the page
dTree.prototype.toString = function() {
var str = '<div class="dtree" style="POSITION: Relative; TOP: 100px;" >\n';
	if (document.getElementById) {
		if (this.config.useCookies) this.selectedNode = this.getSelected();
		str += this.addNode(this.root);
	} else str += 'Browser not supported.';
	str += '</div>';
	if (!this.selectedFound) this.selectedNode = null;
	this.completed = true;
	return str;
};

// Creates the tree structure
dTree.prototype.addNode = function(pNode) {	var str = '';	str += '<table align=center border=0 cellpadding=0 cellspacing=0 >';	str += '	<tr>';	var n=0;
	if (this.config.inOrder) n = pNode._ai;	//alert("NODES LENGTH: "+this.aNodes.length+" N="+n+" NAME: "+pNode.name);
	var childsIndex =0;
	for (n; n<this.aNodes.length; n++) 	{
		if (this.aNodes[n].pid == pNode.id) 		{			var cn = this.aNodes[n];			cn._p = pNode;						cn._ai = n;						this.setCS(cn); // Checks if a node has any children and if it is the last sibling			cn._childIndex = childsIndex++;						if(cn._p._children <= 1)				cn._isOnly;			else			{				if(cn._childIndex == 0)					cn._isLeft=true;				if(cn._childIndex == cn._p._children-1)					cn._isRight=true;			}									if (!cn.target && this.config.target) cn.target = this.config.target;			if (cn._hc && !cn._io && this.config.useCookies) cn._io = this.isOpen(cn.id);			if (!this.config.folderLinks && cn._hc) cn.url = null;			if (this.config.useSelection && cn.id == this.selectedNode && !this.selectedFound) {					cn._is = true;					this.selectedNode = n;					this.selectedFound = true;			}						str += '	<td valign=top align=center ';			str += '>';						str += this.node(cn, n);			str += '	</td>';						//alert("Node '"+cn.name+"' is: ONLY:"+cn._isOnly+" - Left: "+cn._isLeft+" - Right: "+cn._isRight+" PARENT: "+cn._p._children);						if (cn._ls) break;		}		
	}		str += '	</tr>';
	str += '</table>';

	return str;
};

// Creates the node icon, url and text
dTree.prototype.node = function(node, nodeId) {
    if (node._p._children <= 1)
        node._isOnly = true;
    //alert("Node '"+node.name+"' is: ONLY:"+node._isOnly+" - Left: "+node._isLeft+" - Right: "+node._isRight+" PARENT: "+node._p._children);
    //alert("NODE NAME: "+node.name+" HAS CHILDREN: "+node._hc+" INDENT: "+this.indent(node, nodeId));
    var str = '<div class="dTreeNode" style="white-space:nowrap;font-family: Verdana;">';
    str += '<table border="0" cellpadding="0" cellspacing="0" width="100%" >';
    str += '<tr>';
    str += '	<td align="center" width="25%" '
    //alert("Node: "+node.name+" Left TD Decesion -- Node '"+node.name+"' is: ONLY:"+node._isOnly+" - Left: "+node._isLeft+" - Right: "+node._isRight);
    if (this.root.id != node.pid) {
        if (this.config.useLines) {
            if (node._isOnly) {
                str += '';
            }
            else if (node._isLeft) {
                str += '';
            }
            else if (node._isRight) {
                str += ' style="border-top-width:1px;border-top-style:solid;border-top-color:#cc0066;" ';
            }
            else {
                str += 'style="border-top-width:1px;border-top-style:solid;border-top-color:#cc0066;" ';
            }
        }
    }
    str += ' >&nbsp; ';
    str += '	</td>';
    str += '	<td valign="top" style="padding-top:0px;" align="center" width="1%" ';
    str += ' >';
    if (this.root.id != node.pid) /// if this node isn't a first lever node
    {
        str += '<img src="';
        if (this.config.useLines) {
            if (node._isOnly)
                str += this.icon.line
            else if (node._isLeft)
                str += this.icon.leftLine;
            else if (node._isRight)
                str += this.icon.rightLine;
            else
                str += this.icon.middleLine;
        }
        else {
            str += this.icon.empty
        }
        str += '" alt="" />';
    }


    str += '	</td>';
    str += '	<td align="center" width="25%" ';
    if (this.root.id != node.pid) {
        if (this.config.useLines) {
            if (node._isOnly)
                str += ' ';
            else if (node._isLeft)
                str += ' style="border-top-width:1px;border-top-style:solid;border-top-color:#cc0066;"" ';
            else if (node._isRight)
                str += '';
            else
                str += ' style="border-top-width:1px;border-top-style:solid;border-top-color:#cc0066;" ';
        }
    }
    str += ' >&nbsp; ';
    str += '	</td>';
    str += '</tr>';
    //alert("NODE: "+node.name+" is: "+str);
    str += '<tr>';
    str += '	<td align="center" colspan="3">';
    str += '<table border=0 bordercolor=blue cellpadding="0" cellspacing="0" >';
    str += '<tr><td valign=top align=center>' + this.indent(node, nodeId);
    if (this.config.useIcons) {
        if (!node.icon) node.icon = (this.root.id == node.pid) ? this.icon.root : ((node._hc) ? this.icon.folder : this.icon.node);
        if (!node.iconOpen) node.iconOpen = (node._hc) ? this.icon.folderOpen : this.icon.node;
        if (this.root.id == node.pid) {
            node.icon = this.icon.root;
            node.iconOpen = this.icon.root;
        }
        //str += '<img id="i' + this.obj + nodeId + '" src="' + ((node._io) ? node.iconOpen : node.icon) + '" alt="" />';
        //str += '<img id="i' + this.obj + nodeId + '" src="' + ((node._io) ? node.iconOpen : node.icon) + '" onMouseOver="ddrivetip(' + '<table width=100% border=0 cellpadding=5 cellspacing=1 bgcolor=#CCCCCC class=containtd>  <tr>     <td width=50% bgcolor=#999999><font color=#FFFFFF><strong>Member ID</strong></font></td>  </tr>  <tr>     <td>430</td>  </tr>  <tr>     <td bgcolor=#999999><font color=#FFFFFF><strong>Name</strong></font></td>  </tr>  <tr>     <td>Mr-MAHESH BHARDWAJ </td>  </tr>  <tr>     <td bgcolor=#999999><font color=#FFFFFF><strong>Date of Joining</strong></font></td>  </tr>  <tr>     <td>2008-08-07 16:14:54 </td>  </tr>  <tr>     <td bgcolor=#999999><font color=#FFFFFF><strong>Total Status</strong></font></td>  </tr>  <tr>     <td>LEFT:123 , RIGHT:2216 </td>  </tr>  <tr>     <td bgcolor=#999999><font color=#FFFFFF><strong>Product</strong></font></td>  </tr>  <tr>     <td>CODE NO. 01-S.L. &nbsp;</td>  </tr></table>'+  '" alt="" />';
        var strTable = '\'<table width=100% border=1 cellpadding=2 cellspacing=0 bgcolor=#ffffff>';
        var onMouse = '';
        /*strTable+='<tr>';     			strTable+='<td width=50% bgcolor=#999999><font color=#FFFFFF><strong>Member ID</strong></font></td>';  		strTable+='</tr>';				strTable+='<tr>'; 			strTable+='<td>' +node.id +'</td>';  		strTable+='</tr>'; */

        if (node.Isblock != 'Flashed') {
        
//            strTable += '<tr>';
//            strTable += '<td bgcolor=#277AB1><font color=#FFFFFF FACE=Verdana SIZE=1><strong>Sponsor</strong></font></td>';
//            strTable += '<td><font FACE=Verdana SIZE=1>' + node.sponsor + '</font></td>';
//            strTable += '</tr>';



            strTable += '<tr>';
            strTable += '<td bgcolor=#277AB1><font color=#FFFFFF FACE=Verdana SIZE=1><strong>Member Name</strong></font></td>';
            strTable += '<td><font FACE=Verdana SIZE=1>' + node.nodename + '</font></td>';
            strTable += '</tr>';


//            if (node.Mobile != '0') {
//                strTable += '<tr>';
//                strTable += '<td bgcolor=#277AB1><font color=#FFFFFF FACE=Verdana SIZE=1><strong>Mobile No.</strong></font></td>';
//                strTable += '<td><font FACE=Verdana SIZE=1>' + node.Mobile + '&nbsp;</font></td>';
//                strTable += '</tr>';
//            }

            strTable += '<tr>';
            strTable += '<td bgcolor=#277AB1><font color=#FFFFFF FACE=Verdana SIZE=1><strong>Status</strong></font></td>';
            strTable += '<td><font FACE=Verdana SIZE=1>' + node.idstatus + '</font></td>';
            strTable += '</tr>';
            /*	strTable+='<tr>'; 			strTable+='<td bgcolor=#999999><font color=#FFFFFF><strong>Sponsor Name</strong></font></td>';  		strTable+='</tr>';				strTable+='<tr>'; 			strTable+='<td>'+ node.sponsor + '</td>';  		strTable+='</tr>';				strTable+='<tr>'; 			strTable+='<td bgcolor=#999999><font color=#FFFFFF><strong>UpLiner</strong></font></td>';  		strTable+='</tr>';				strTable+='<tr>'; 			strTable+='<td>'+ node.upliner + '</td>';  		strTable+='</tr>';*/
            /*strTable+='<tr>'; 			strTable+='<td bgcolor=#999999><font color=#FFFFFF><strong>Date of Joining</strong></font></td>';  		strTable+='</tr>';				strTable+='<tr>'; 			strTable+='<td>' + node.doj +'</td> '; 		strTable+='</tr>';*/
            strTable += '<tr>';
            strTable += '<td bgcolor=#277AB1><font color=#FFFFFF FACE=Verdana SIZE=1><strong>Current Status</strong></font></td>';
            strTable += '<td><font FACE=Verdana SIZE=1>Direct :' + node.leftbv + ', Indirect :' + node.rightbv + '</font> </td>';
            strTable += '</tr>';

            strTable += '<tr>';
            strTable += '<td bgcolor=#277AB1><font color=#FFFFFF FACE=Verdana SIZE=1><strong>Active Status</strong></font></td>';
            strTable += '<td><font FACE=Verdana SIZE=1>Direct :' + node.DirctLeftActive + ', Indirect :' + node.DirectRightActive + '</font> </td>';
            strTable += '</tr>';

            strTable += '<tr>';
            strTable += '<td bgcolor=#277AB1><font color=#FFFFFF FACE=Verdana SIZE=1><strong>Joining Type</strong></font></td>';
            strTable += '<td><font FACE=Verdana SIZE=1>' + node.category + '&nbsp;</td>';
            strTable += '</tr>';
            strTable += '<tr>';
            strTable += '<td bgcolor=#277AB1><font color=#FFFFFF FACE=Verdana SIZE=1><strong>Activation Date</strong></font></td>';
            strTable += '<td><font FACE=Verdana SIZE=1>' + node.UpgradeDate + '&nbsp;</td>';
            strTable += '</tr>';
        }
        else {

            strTable += '<tr>';
            strTable += '<td ' + tooltiptdlbl + '><font ' + tooltipfontlbl + '>Status :</font></td>';
            strTable += '<td ' + tooltiptdtxt + '><font ' + tooltipfonttxt + '>' + node.Isblock + '</td>';
            strTable += '</tr>';
        
        
        }


        strTable += '</table>\'';
        if (node.pid == -1) {
            //onMouse = '"';
            onMouse = '" onMouseOver="ddrivetip(' + strTable + ',' + tootipwidth + ')"' + '" onMouseOut="hideddrivetip()"';
        }
        else {
            if (node.id > 0)
            { onMouse = '" onMouseOver="ddrivetip(' + strTable + ')"' + '" onMouseOut="hideddrivetip()"'; }
            else {
                onMouse = '"';
            }
        }
        str += '<img id="i' + this.obj + nodeId + '" src="' + ((node._io) ? node.iconOpen : node.icon) + onMouse + ' alt="" width="50" height="50" />';
    }
    str += "</td></tr><tr><td valign=top align=center style='white-space:nowrap'>";
    if (node.url) {
        str += '<a id="s' + this.obj + nodeId + '" class="' + ((this.config.useSelection) ? ((node._is ? 'nodeSel' : 'node')) : 'node') + '" href="' + node.url + '"';
        if (node.title) str += ' title="' + node.title + '"';
        if (node.target) str += ' target="' + node.target + '"';
        if (this.config.useStatusText) str += ' onmouseover="window.status=\'' + node.name + '\';return true;" onmouseout="window.status=\'\';return true;" ';
        if (this.config.useSelection && ((node._hc && this.config.folderLinks) || !node._hc))
            str += ' onclick="javascript: ' + this.obj + '.s(' + nodeId + ');"';
        str += '>';
    }
    else if ((!this.config.folderLinks || !node.url) && node._hc && node.pid != this.root.id)
        str += '<a href="javascript: ' + this.obj + '.o(' + nodeId + ');" class="node">';
    str += node.name;
    if (node.url || ((!this.config.folderLinks || !node.url) && node._hc)) str += '</a>';
    str += '</div>';
    str += '</td></tr></table>';
    str += '</td></tr></table>';
    if (node._hc) {
        str += '<div id="d' + this.obj + nodeId + '" class="clip" style="display:' + ((node._io) ? 'block' : 'none') + ';">';
        str += '<table border=0 cellpadding=0 cellspacing=0>';
        str += '<tr><td height="9" align="center"><img src="' + this.icon.smallLine + '" alt="" border=0></td></tr>';
        str += '<tr><td>';
        str += this.addNode(node);
        str += '</td></tr></table>';
        str += '</div>';
    }
    this.aIndent.pop();
    return str;
};

// Adds the empty and line icons
dTree.prototype.indent = function(node, nodeId) {
	var str = '';		
	(node._ls) ? this.aIndent.push(0) : this.aIndent.push(1);
	if (node._hc) 	{		str += '<a href="javascript: ' + this.obj + '.o(' + nodeId + ');"><img id="j' + this.obj + nodeId + '" src="';		str += (node._io) ? this.icon.nlMinus : this.icon.nlPlus;
		str += '" alt="" /></a>';	}		return str;};

// Checks if a node has any children and if it is the last sibling
dTree.prototype.setCS = function(node) {
	var lastId;		var children =0;
	for (var n=0; n<this.aNodes.length; n++) {
		if (this.aNodes[n].pid == node.id)		{		 node._hc = true;		 children ++;		}
		if (this.aNodes[n].pid == node.pid) lastId = this.aNodes[n].id;
	}	node._children = children;
	if (lastId==node.id) node._ls = true;
};

// Returns the selected node
dTree.prototype.getSelected = function() {
	var sn = this.getCookie('cs' + this.obj);
	return (sn) ? sn : null;
};

// Highlights the selected node
dTree.prototype.s = function(id) {
	if (!this.config.useSelection) return;
	var cn = this.aNodes[id];
	if (cn._hc && !this.config.folderLinks) return;
	if (this.selectedNode != id) {
		if (this.selectedNode || this.selectedNode==0) {
			eOld = document.getElementById("s" + this.obj + this.selectedNode);
			eOld.className = "node";
		}
		eNew = document.getElementById("s" + this.obj + id);
		eNew.className = "nodeSel";
		this.selectedNode = id;
		if (this.config.useCookies) this.setCookie('cs' + this.obj, cn.id);
	}
};

// Toggle Open or close
dTree.prototype.o = function(id) {
	var cn = this.aNodes[id];
	this.nodeStatus(!cn._io, id, cn._ls);
	cn._io = !cn._io;
	if (this.config.closeSameLevel) this.closeLevel(cn);
	if (this.config.useCookies) this.updateCookie();
};

// Open or close all nodes
dTree.prototype.oAll = function(status) {
	for (var n=0; n<this.aNodes.length; n++) {
		if (this.aNodes[n]._hc && this.aNodes[n].pid != this.root.id) {
			this.nodeStatus(status, n, this.aNodes[n]._ls)
			this.aNodes[n]._io = status;
		}
	}
	if (this.config.useCookies) this.updateCookie();
};

// Opens the tree to a specific node
dTree.prototype.openTo = function(nId, bSelect, bFirst) {
	if (!bFirst) {
		for (var n=0; n<this.aNodes.length; n++) {
			if (this.aNodes[n].id == nId) {
				nId=n;
				break;
			}
		}
	}
	var cn=this.aNodes[nId];
	if (cn.pid==this.root.id || !cn._p) return;
	cn._io = true;
	cn._is = bSelect;
	if (this.completed && cn._hc) this.nodeStatus(true, cn._ai, cn._ls);
	if (this.completed && bSelect) this.s(cn._ai);
	else if (bSelect) this._sn=cn._ai;
	this.openTo(cn._p._ai, false, true);
};

// Closes all nodes on the same level as certain node
dTree.prototype.closeLevel = function(node) {
	for (var n=0; n<this.aNodes.length; n++) {
		if (this.aNodes[n].pid == node.pid && this.aNodes[n].id != node.id && this.aNodes[n]._hc) {
			this.nodeStatus(false, n, this.aNodes[n]._ls);
			this.aNodes[n]._io = false;
			this.closeAllChildren(this.aNodes[n]);
		}
	}
}

// Closes all children of a node
dTree.prototype.closeAllChildren = function(node) {
	for (var n=0; n<this.aNodes.length; n++) {
		if (this.aNodes[n].pid == node.id && this.aNodes[n]._hc) {
			if (this.aNodes[n]._io) this.nodeStatus(false, n, this.aNodes[n]._ls);
			this.aNodes[n]._io = false;
			this.closeAllChildren(this.aNodes[n]);		
		}
	}
}

// Change the status of a node(open or closed)
dTree.prototype.nodeStatus = function(status, id, bottom) {
	eDiv	= document.getElementById('d' + this.obj + id);
	eJoin	= document.getElementById('j' + this.obj + id);
	if (this.config.useIcons) {
		eIcon	= document.getElementById('i' + this.obj + id);
		eIcon.src = (status) ? this.aNodes[id].iconOpen : this.aNodes[id].icon;
	}
	eJoin.src = ((status)?this.icon.nlMinus:this.icon.nlPlus);
	eDiv.style.display = (status) ? 'block': 'none';
};


// [Cookie] Clears a cookie
dTree.prototype.clearCookie = function() {
	var now = new Date();
	var yesterday = new Date(now.getTime() - 1000 * 60 * 60 * 24);
	this.setCookie('co'+this.obj, 'cookieValue', yesterday);
	this.setCookie('cs'+this.obj, 'cookieValue', yesterday);
};

// [Cookie] Sets value in a cookie
dTree.prototype.setCookie = function(cookieName, cookieValue, expires, path, domain, secure) {
	document.cookie =
		escape(cookieName) + '=' + escape(cookieValue)
		+ (expires ? '; expires=' + expires.toGMTString() : '')
		+ (path ? '; path=' + path : '')
		+ (domain ? '; domain=' + domain : '')
		+ (secure ? '; secure' : '');
};

// [Cookie] Gets a value from a cookie
dTree.prototype.getCookie = function(cookieName) {
	var cookieValue = '';
	var posName = document.cookie.indexOf(escape(cookieName) + '=');
	if (posName != -1) {
		var posValue = posName + (escape(cookieName) + '=').length;
		var endPos = document.cookie.indexOf(';', posValue);
		if (endPos != -1) cookieValue = unescape(document.cookie.substring(posValue, endPos));
		else cookieValue = unescape(document.cookie.substring(posValue));
	}
	return (cookieValue);
};

// [Cookie] Returns ids of open nodes as a string
dTree.prototype.updateCookie = function() {
	var str = '';
	for (var n=0; n<this.aNodes.length; n++) {
		if (this.aNodes[n]._io && this.aNodes[n].pid != this.root.id) {
			if (str) str += '.';
			str += this.aNodes[n].id;
		}
	}
	this.setCookie('co' + this.obj, str);
};

// [Cookie] Checks if a node id is in a cookie
dTree.prototype.isOpen = function(id) {
	var aOpen = this.getCookie('co' + this.obj).split('.');
	for (var n=0; n<aOpen.length; n++)
		if (aOpen[n] == id) return true;
	return false;
};

// If Push and pop is not implemented by the browser
if (!Array.prototype.push) {
	Array.prototype.push = function array_push() {
		for(var i=0;i<arguments.length;i++)
			this[this.length]=arguments[i];
		return this.length;
	}
};
if (!Array.prototype.pop) {
	Array.prototype.pop = function array_pop() {
		lastElement = this[this.length-1];
		this.length = Math.max(this.length-1,0);
		return lastElement;
	}
};
