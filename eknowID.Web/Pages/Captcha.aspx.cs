﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using eknowID.Pages;

public partial class Captcha : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Bitmap bmp = new Bitmap(Server.MapPath("~\\images\\captcha2.jpg"));
        MemoryStream memStream = new MemoryStream();

        int width = bmp.Width;
        int height = bmp.Height;
        string familyName = "Arial";
        string captchaText =Request.Cookies["Captcha"]["value"];

        Bitmap bitmap = new Bitmap(bmp, new Size(width, height));
        Graphics g = Graphics.FromImage(bitmap);
        g.SmoothingMode = SmoothingMode.AntiAlias;

        int xCopyright = width - 150;
        int yCopyright = height - 50;

        Rectangle rect;
        Font font;
        int newfontsize = 45;

        font = new Font(familyName, newfontsize, FontStyle.Italic);

        rect = new Rectangle(xCopyright, yCopyright, 0, 0);

        StringFormat format = new StringFormat();
        format.Alignment = StringAlignment.Near;
        format.LineAlignment = StringAlignment.Near;
        GraphicsPath path = new GraphicsPath();
        path.AddString(captchaText, font.FontFamily, (int)font.Style, font.Size, rect, format);

        HatchBrush hatchBrush = new HatchBrush(
            HatchStyle.LargeConfetti,
            Color.FromName("White"),
            Color.FromName("Black"));
        g.FillPath(hatchBrush, path);

        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.ContentType = "image/jpeg";


        bitmap.Save(memStream, ImageFormat.Jpeg);

        bmp.Dispose();
        font.Dispose();
        hatchBrush.Dispose();
        g.Dispose();

        memStream.WriteTo(HttpContext.Current.Response.OutputStream);
        bitmap.Dispose();        
    }
}