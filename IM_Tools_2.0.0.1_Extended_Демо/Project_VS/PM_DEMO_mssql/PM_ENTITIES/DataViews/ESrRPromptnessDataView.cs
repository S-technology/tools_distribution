/********************************************************************************/
/*                                                                              */
/*Copyright (c) 1999,2011   Information & Management Ltd.                       */
/*                                                                              */
/*   Модуль таблицы PM_OTLADKA_DATA.DBO.SR_R_PROMPTNESS_SRPR                    */
/*                                                                              */
/*   NAME  ESrRPromptness.cs    SCOPE    ....                                   */
/*                                                                              */
/*   DESCRIPTION                                                                */
/*     Срочность выполнения                                                     */
/*                                                                              */
/*   AUTHOR                                                                     */
/*                                                                              */
/********************************************************************************/
 
/*
    17.03.2011  Automatic  Первоначальная редакция
                                                                               */
 
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using S_;
using S_.WindowsForms;
using u_ierarch;

namespace MP.WindowsForms {
  //s_DataViewObject.Register(typeof(SrRPromptnessView));

  public class SrRPromptnessView : s_DataViewObject {
    public static string GetXml() {
      return
        "<Class\r\n" +
        "       DefaultCaption='ТИП НАЧИСЛЕНИЯ В ЦЕНЕ'\r\n" +
        "       Data='SrRPromptnessData'\r\n" +
        ">\r\n" +
        "  <Version Major='1' Minor='0' Relase ='0' Build='1' Date='20110317' />" +
        "  <Comment>. . .</Comment>\r\n" +
        "</Class>"
     ;
    }//GetXML

  #region заготовки для перекрытия методов
/*----------------------------------------------------------*/
/*
    protected override void OnCellImageGet(s_ViewCellImageGetEventArgs e) {
//    . . .
  }
/**/
/*----------------------------------------------------------*/
/*
    protected override void OnCellImageClick(s_ViewCellImageClickEventArgs e) {
      base.OnCellImageClick(e);
      if (e.Handled)
        return;
//    . . .
//    e.Handled = true;
    }
/**/
/*----------------------------------------------------------*/
/*
    protected override void OnOpening(CancelEventArgs e) {
      base.OnOpening(e);
      if (e.Cancel)
        return;
//    . . .
    }
/**/
/*----------------------------------------------------------*/
/*
    protected override void OnOpened(EventArgs e) {
      base.OnOpened(e);
//    . . .
    }
/**/
/*----------------------------------------------------------*/
/*
    protected override void OnClosing(CancelEventArgs e) {
      base.OnClosing(e);
      if (e.Cancel)
        return;
//    . . .
    }
/**/
/*----------------------------------------------------------*/
/*
    protected override void OnClosed(EventArgs e) {
      base.OnClosed(e);
//    . . .
    }
/**/
/*----------------------------------------------------------*/
/*
    protected override void OnInitialization(EventArgs e) {
      base.OnInitialization(e);
//    . . .
    }
/**/
/*----------------------------------------------------------*/
/*
    protected override void OnFinalization(EventArgs e) {
      base.OnFinalization(e);
//    . . .
    }
/**/
  #endregion

  }
}
