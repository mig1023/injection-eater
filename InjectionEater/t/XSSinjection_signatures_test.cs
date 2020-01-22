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
    }
}
