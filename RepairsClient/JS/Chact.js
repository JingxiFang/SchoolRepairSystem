
       


        //当按下回车时触发提交事件
        //当光标在文本框中的时候 按下回车 提交消息
        txtContent.onkeydown = txtContentKeyDown;
        function txtContentKeyDown(evt) {
            evt = evt || event;
            if (evt.keyCode == 13) {
                if (!btn.disabled) {
                    btn.click();
                }
            }
        }






        //当前消息接收标记
        var lastIndex = -1;

        //避免重复提交获取请求
        var isRun = false;

        //ajax与后台通讯
        function ajax(para, fn) {
            // ？？？   这是啥？？？？？？
            var ajaxObject = window.ActiveXObject ? new ActiveXObject("Microsoft.XMLHTTP") : new XMLHttpRequest();
            ajaxObject.onreadystatechange = function ajaxStateChange() {
                if (ajaxObject.readyState == 4) {
                    if (ajaxObject.status == 200) {
                        fn(ajaxObject.responseText);
                    }
                    else {
                        alert('网络繁忙!');
                    }
                }
            };
            ajaxObject.open('POST', pageUrl, true); //啥意思
            ajaxObject.setRequestHeader("Content-Type", "application/x-www-form-urlencoded;charset=Utf-8");
            ajaxObject.send(para);
            return ajaxObject;
        }

        //发送消息
        function sendMsg() {
           
            if (txtContent.value == '') {
                alert('内容必须填写！');
                txtContent.focus();
                return;
            }

            btn.disabled = true;
            var para = 'uname=' + encodeURIComponent(txtName.value) + '&content=' + encodeURIComponent(txtContent.value) + '&to=' + '<%=friID %>';
            // var para='uname'+
            ajax(para, sendMsgBack);
        }

        function getFriName() {

        }

        //发送消息后，服务器返回
        function sendMsgBack(str)//str在哪里用到了？
        {
            btn.disabled = false;
            txtContent.value = '';
            txtContent.focus();
            getMsg();
        }

        //获取消息
        function getMsg() {
            //??????这是啥
            if (isRun)
                return;
            isRun = true;
            ajax('lastIndex=' + lastIndex, getMsgBack);
        }

        //？？？这是啥？？？
        var autoRun = null;
        //获取消息，服务器返回
        function getMsgBack(str) {
            if (autoRun)
                clearTimeout(autoRun);  //？？？这是什么意思？？？
            if (lastIndex == -1) {
                divMsg.innerHTML = '';
            }
            var strs = str.split('<');
            lastIndex = strs[0];
            var strHTML = '';
            for (var i = 1; i < strs.length; i++) {
                var item = strs[i].split('>');
                var contentClass = '';
                if (item[2] == userId) {
                    contentClass = 'spanMe';
                }
                else if (item[4] == userId) {
                    contentClass = 'spanToMe';
                }
                strHTML += '<div>';
                strHTML += '<i>' + item[0] + '</i> ';
                if (item[2] == userId) {
                    strHTML += '<b>' + (item[1] || item[2]) + '</b>';
                }
                else {
                    strHTML += '<b style="cursor:pointer;" onclick="toSay(this);" title="' + item[2] + '">' + (item[1] || item[2]) + '</b>';
                }
                if (item[4] != '') {
                    strHTML += ' 对 <b>' + (item[5] || item[4]) + '</b>';
                }
                strHTML += '<br><span class="' + contentClass + '">' + item[3] + '</span>';
                strHTML += '</div>';
            }
            divMsg.innerHTML = strHTML + divMsg.innerHTML;
            isRun = false;

            //每隔1秒从服务器获取一次数据
            autoRun = setTimeout(getMsg, 1000);
        }

        //对指定人发信息
        function toSay(o) {
            chkTo.checked = true;
            chkTo.style.display = 'inline';
            lblTo.innerHTML = o.innerHTML;
            lblTo.style.display = 'inline';
            to = o.title;
            txtContent.focus();
        }

        getMsg();
