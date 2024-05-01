(function(Global)
{
 "use strict";
 var Project8,Client,Project8_Templates,WebSharper,UI,Templating,Runtime,Server,ProviderBuilder,TemplateHoleModule,Text,VarStr,VarBool,Handler,TemplateInstance,Forms,Form,Runtime$1,Pervasives,Validation,Concurrency,Utils,Strings,Arrays,Slice,TemplateHole,Var$1,TextView,Client$1,Templates;
 Project8=Global.Project8=Global.Project8||{};
 Client=Project8.Client=Project8.Client||{};
 Project8_Templates=Global.Project8_Templates=Global.Project8_Templates||{};
 WebSharper=Global.WebSharper;
 UI=WebSharper&&WebSharper.UI;
 Templating=UI&&UI.Templating;
 Runtime=Templating&&Templating.Runtime;
 Server=Runtime&&Runtime.Server;
 ProviderBuilder=Server&&Server.ProviderBuilder;
 TemplateHoleModule=UI&&UI.TemplateHoleModule;
 Text=TemplateHoleModule&&TemplateHoleModule.Text;
 VarStr=TemplateHoleModule&&TemplateHoleModule.VarStr;
 VarBool=TemplateHoleModule&&TemplateHoleModule.VarBool;
 Handler=Server&&Server.Handler;
 TemplateInstance=Server&&Server.TemplateInstance;
 Forms=WebSharper&&WebSharper.Forms;
 Form=Forms&&Forms.Form;
 Runtime$1=WebSharper&&WebSharper.Runtime;
 Pervasives=Forms&&Forms.Pervasives;
 Validation=Forms&&Forms.Validation;
 Concurrency=WebSharper&&WebSharper.Concurrency;
 Utils=WebSharper&&WebSharper.Utils;
 Strings=WebSharper&&WebSharper.Strings;
 Arrays=WebSharper&&WebSharper.Arrays;
 Slice=WebSharper&&WebSharper.Slice;
 TemplateHole=UI&&UI.TemplateHole;
 Var$1=UI&&UI.Var$1;
 TextView=TemplateHoleModule&&TemplateHoleModule.TextView;
 Client$1=UI&&UI.Client;
 Templates=Client$1&&Client$1.Templates;
 Client.CreditRequest$57$26=function(submitter)
 {
  return function()
  {
   submitter.Trigger();
  };
 };
 Client.CreditRequest=function()
 {
  function r(name,ux,options,message,pp,submitter)
  {
   var b,t,_this,_this$1,_this$2,_this$3,_this$4,p,i;
   return(b=(t=(_this=(_this$1=(_this$2=(_this$3=(_this$4=new ProviderBuilder.New$1(),(_this$4.h.push(new Text.New("title","Thank you for leave a feedback")),_this$4)),(_this$3.h.push(new VarStr.New("name",name)),_this$3)),(_this$2.h.push(new VarStr.New("ux",ux)),_this$2)),(_this$1.h.push(new VarStr.New("message",message)),_this$1)),(_this.h.push(new VarBool.New("privacypolicy",pp)),_this)),(t.h.push(Handler.EventQ2(t.k,"onsubmit",function()
   {
    return t.i;
   },function()
   {
    submitter.Trigger();
   })),t)),(p=Handler.CompleteHoles(b.k,b.h,[["name",0,null],["ux",0,null],["message",0,null],["privacypolicy",2,null]]),(i=new TemplateInstance.New(p[1],Project8_Templates.form1(p[0])),b.i=i,i))).get_Doc();
  }
  return Form.Render(Runtime$1.Curried(r,6),Form.Run(function(data)
  {
   Global.alert("You submitted: "+Global.String(data));
  },Form.WithSubmit(Pervasives.op_LessMultiplyGreater(Pervasives.op_LessMultiplyGreater(Pervasives.op_LessMultiplyGreater(Pervasives.op_LessMultiplyGreater(Pervasives.op_LessMultiplyGreater(Form.Return(Runtime$1.Curried(function(name,ux,options,message,pp)
  {
   return[name,ux,options,message,pp];
  },5)),Validation.IsNotEmpty("Can't be empty",Form.Yield(""))),Form.Yield("")),Form.Yield("")),Form.Yield("")),Form.Yield(false)))));
 };
 Client.Main$22$20=function(rvCapitalized)
 {
  return function(e)
  {
   var _;
   Concurrency.StartImmediate((_=null,Concurrency.Delay(function()
   {
    rvCapitalized.Set("Hello, "+Utils.toSafe(Strings.concat(" ",Arrays.map(function(word)
    {
     var c;
     return(c=word[0],Global.String(c)).toUpperCase()+Slice.string(word,{
      $:1,
      $0:1
     },null).toLowerCase();
    },Strings.SplitChars(TemplateHole.Value(e.Vars.Hole("texter")).Get(),[" "],1))))+"! Welcome this webshaeper templating");
    return Concurrency.Zero();
   })),null);
  };
 };
 Client.Main=function()
 {
  var rvCapitalized,b,R,_this,t,p,i;
  rvCapitalized=Var$1.Create$1("");
  return(b=(R=rvCapitalized.get_View(),(_this=(t=new ProviderBuilder.New$1(),(t.h.push(Handler.EventQ2(t.k,"onsend",function()
  {
   return t.i;
  },function(e)
  {
   var _;
   Concurrency.StartImmediate((_=null,Concurrency.Delay(function()
   {
    rvCapitalized.Set("Hello, "+Utils.toSafe(Strings.concat(" ",Arrays.map(function(word)
    {
     var c;
     return(c=word[0],Global.String(c)).toUpperCase()+Slice.string(word,{
      $:1,
      $0:1
     },null).toLowerCase();
    },Strings.SplitChars(TemplateHole.Value(e.Vars.Hole("texter")).Get(),[" "],1))))+"! Welcome this webshaeper templating");
    return Concurrency.Zero();
   })),null);
  })),t)),(_this.h.push(new TextView.New("reversed",R)),_this))),(p=Handler.CompleteHoles(b.k,b.h,[["texter",0,null]]),(i=new TemplateInstance.New(p[1],Project8_Templates.mainform(p[0])),b.i=i,i))).get_Doc();
 };
 Project8_Templates.form1=function(h)
 {
  Templates.LoadLocalTemplates("main");
  return h?Templates.NamedTemplate("main",{
   $:1,
   $0:"form1"
  },h):void 0;
 };
 Project8_Templates.mainform=function(h)
 {
  Templates.LoadLocalTemplates("main");
  return h?Templates.NamedTemplate("main",{
   $:1,
   $0:"mainform"
  },h):void 0;
 };
}(self));
