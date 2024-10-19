using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using ImageQuantization;
using System.Drawing.Text;


namespace RXServer
{
    namespace Library
    {

        #region public class Mail
        public class Mail
        {
            //static string CLASSNAME = "[Namespace::RXServer::Library][Class::Mail]";
        }
        #endregion public class Mail

        #region public class File
        public static class File
        {
            static string CLASSNAME = "[Namespace::RXServer::Library][Class::File]";
            public static String GetTempFileName()
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::GetTempFileName]";
                try
                {
                    return Path.GetFileNameWithoutExtension(Path.GetTempFileName()) + DateTime.Now.Ticks.ToString(); 
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, String.Empty);
                    return String.Empty;
                }
            }
        }
        #endregion public class File
        
        #region public class Image
        public static class Image
        {
            static string CLASSNAME = "[Namespace::RXServer::Library][Class::Image]";
            public static void CreateMenuItemImage(
                String _Text,
                Int32 _X,
                Int32 _Y,
                Int32[] _FontColor,
                String _FontName,
                float _FontSize,
                FontStyle _FontStyle,
                GraphicsUnit _FontUnit,
                String _SourceImageFileName,
                String _DestinationImageFileName)
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::CreateMenuItemImage]";
                try
                {
                    if (_FontSize.Equals(0))
                        return;

                    Font f = new Font(_FontName, _FontSize, _FontStyle, _FontUnit);
                    SolidBrush sb = new SolidBrush(Color.FromArgb(_FontColor[0], _FontColor[1], _FontColor[2]));

                    Graphics g1 = Graphics.FromImage(new Bitmap(1, 1));
                    Int32 TextWidthInt32 = (Int32)g1.MeasureString(_Text, f).Width + 6;

                    System.Drawing.Image i1 = System.Drawing.Image.FromFile(_SourceImageFileName);
                    Bitmap b2 = new Bitmap(i1);

                    Bitmap b3 = b2.Clone(new RectangleF(0, 0, TextWidthInt32 > b2.Width ? b2.Width : TextWidthInt32, b2.Height), PixelFormat.DontCare);

                    Graphics g2 = Graphics.FromImage(b3);

                    g2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                    g2.SmoothingMode = SmoothingMode.AntiAlias;
                    g2.DrawImage(b3, 10, 151);

                    g2.DrawString(_Text, f, sb, new RectangleF(_X, _Y, TextWidthInt32, 20), StringFormat.GenericDefault);

                    OctreeQuantizer quantizer = new OctreeQuantizer(255, 8);
                    using (Bitmap BMPQuantized = quantizer.Quantize(b3))
                    {
                        BMPQuantized.Save(_DestinationImageFileName, System.Drawing.Imaging.ImageFormat.Gif);
                    }
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, String.Empty);
                }
            }

            public static void CreateTeaserImage(
                String _HeaderText,
                String _IngressText,
                Int32 _X,
                Int32 _Y,
                Int32[] _HeaderFontColor,
                String _HeaderFontName,
                float _HeaderFontSize,
                FontStyle _HeaderFontStyle,
                GraphicsUnit _HeaderFontUnit,
                Int32[] _IngressFontColor,
                String _IngressFontName,
                float _IngressFontSize,
                FontStyle _IngressFontStyle,
                GraphicsUnit _IngressFontUnit,
                String _SourceImageFileName,
                String _DestinationImageFileName)
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::CreateTeaserImage]";
                try
                {
                    if (_HeaderFontSize.Equals(0))
                        return;

                    if (_IngressFontSize.Equals(0))
                        return;

                    Font fHeader = new Font(_HeaderFontName, _HeaderFontSize, _HeaderFontStyle, _HeaderFontUnit);
                    Font fIngress = new Font(_IngressFontName, _IngressFontSize, _IngressFontStyle, _IngressFontUnit);
                    SolidBrush sbHeader = new SolidBrush(Color.FromArgb(_HeaderFontColor[0], _HeaderFontColor[1], _HeaderFontColor[2]));
                    SolidBrush sbIngress = new SolidBrush(Color.FromArgb(_IngressFontColor[0], _IngressFontColor[1], _IngressFontColor[2]));

                    Graphics g1 = Graphics.FromImage(new Bitmap(1, 1));
                    Int32 HeaderTextWidthInt32 = (Int32)g1.MeasureString(_HeaderText, fHeader).Width + 6;
                    Int32 IngressTextWidthInt32 = (Int32)g1.MeasureString(_IngressText, fIngress).Width + 6;

                    System.Drawing.Image i1 = System.Drawing.Image.FromFile(_SourceImageFileName);
                    Bitmap b2 = new Bitmap(i1);

                    Bitmap b3 = b2.Clone(new RectangleF(0, 0, b2.Width, b2.Height), PixelFormat.DontCare);

                    Graphics g2 = Graphics.FromImage(b3);
                    Graphics gi = Graphics.FromImage(b3);

                    g2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                    g2.SmoothingMode = SmoothingMode.AntiAlias;
                    g2.DrawImage(b3, _X, _Y);
                    gi.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                    gi.SmoothingMode = SmoothingMode.AntiAlias;
                    gi.DrawImage(b3, _X, _Y);

                    g2.DrawString(_HeaderText, fHeader, sbHeader, new RectangleF(_X, _Y, b2.Width - (_X * 2), 24), StringFormat.GenericDefault);
                    gi.DrawString(_IngressText, fIngress, sbIngress, new RectangleF(_X, _Y + 30, b2.Width - (_X * 2), 65), StringFormat.GenericDefault);

                    OctreeQuantizer quantizer = new OctreeQuantizer(255, 8);
                    using (Bitmap BMPQuantized = quantizer.Quantize(b3))
                    {
                        BMPQuantized.Save(_DestinationImageFileName, System.Drawing.Imaging.ImageFormat.Gif);
                    }
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, String.Empty);
                }
            }

            public static void CreateHeaderImage(
                String _Text,
                Int32 _X,
                Int32 _Y,
                Int32[] _FontColor,
                String _FontName,
                float _FontSize,
                FontStyle _FontStyle,
                GraphicsUnit _FontUnit,
                String _SourceImageFileName,
                String _DestinationImageFileName)
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::CreateHeaderImage]";
                try
                {
                    if (_FontSize.Equals(0))
                        return;

                    Font f = new Font(_FontName, _FontSize, _FontStyle, _FontUnit);
                    SolidBrush sb = new SolidBrush(Color.FromArgb(_FontColor[0], _FontColor[1], _FontColor[2]));

                    Graphics g1 = Graphics.FromImage(new Bitmap(1, 1));
                    Int32 TextWidthInt32 = (Int32)g1.MeasureString(_Text, f).Width + 6;

                    System.Drawing.Image i1 = System.Drawing.Image.FromFile(_SourceImageFileName);
                    Bitmap b2 = new Bitmap(i1);

                    Bitmap b3 = b2.Clone(new RectangleF(0, 0, TextWidthInt32 > b2.Width ? b2.Width : TextWidthInt32, b2.Height), PixelFormat.DontCare);

                    Graphics g2 = Graphics.FromImage(b3);

                    g2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                    g2.SmoothingMode = SmoothingMode.AntiAlias;
                    g2.DrawImage(b3, 10, 151);

                    g2.DrawString(_Text, f, sb, new RectangleF(_X, _Y, TextWidthInt32, 20), StringFormat.GenericDefault);

                    OctreeQuantizer quantizer = new OctreeQuantizer(255, 8);
                    using (Bitmap BMPQuantized = quantizer.Quantize(b3))
                    {
                        BMPQuantized.Save(_DestinationImageFileName, System.Drawing.Imaging.ImageFormat.Gif);
                    }
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, String.Empty);
                }
            }

            public static void CreateSingleHeaderImage(
                String _Text,
                Int32 _X,
                Int32 _Y,
                Int32[] _FontColor,
                String _FontName,
                float _FontSize,
                FontStyle _FontStyle,
                GraphicsUnit _FontUnit,
                String _SourceImageFileName,
                String _DestinationImageFileName)
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::CreateSingleHeaderImage]";
                try
                {
                    if (_FontSize.Equals(0))
                        return;

                    Font f = new Font(_FontName, _FontSize, _FontStyle, _FontUnit);
                    SolidBrush sb = new SolidBrush(Color.FromArgb(_FontColor[0], _FontColor[1], _FontColor[2]));

                    Graphics g1 = Graphics.FromImage(new Bitmap(1, 1));
                    Int32 TextWidthInt32 = (Int32)g1.MeasureString(_Text, f).Width + 6;

                    System.Drawing.Image i1 = System.Drawing.Image.FromFile(_SourceImageFileName);
                    Bitmap b2 = new Bitmap(i1);

                    Bitmap b3 = b2.Clone(new RectangleF(0, 0, TextWidthInt32 > b2.Width ? b2.Width : TextWidthInt32, b2.Height), PixelFormat.DontCare);

                    Graphics g2 = Graphics.FromImage(b3);

                    g2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                    g2.SmoothingMode = SmoothingMode.AntiAlias;
                    g2.DrawImage(b3, 10, 151);

                    g2.DrawString(_Text, f, sb, new RectangleF(_X, _Y, TextWidthInt32, 22), StringFormat.GenericDefault);

                    OctreeQuantizer quantizer = new OctreeQuantizer(255, 8);
                    using (Bitmap BMPQuantized = quantizer.Quantize(b3))
                    {
                        BMPQuantized.Save(_DestinationImageFileName, System.Drawing.Imaging.ImageFormat.Gif);
                    }
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, String.Empty);
                }
            }

            public static void CreateComboHeaderImage(
                String _TextFirst,
                Int32 _XFirst,
                Int32 _YFirst,
                Int32[] _FontColorFirst,
                String _FontNameFirst,
                float _FontSizeFirst,
                FontStyle _FontStyleFirst,
                GraphicsUnit _FontUnitFirst,
                String _TextSecond,
                Int32 _XSecond,
                Int32 _YSecond,
                Int32[] _FontColorSecond,
                String _FontNameSecond,
                float _FontSizeSecond,
                FontStyle _FontStyleSecond,
                GraphicsUnit _FontUnitSecond,
                String _SourceImageFileName,
                String _DestinationImageFileName)
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::CreateComboHeaderImage]";
                try
                {
                    if (_FontSizeFirst < 1 || _FontSizeSecond < 1 || _SourceImageFileName.Length < 1)
                        return;
                    Font fFirst = new Font(_FontNameFirst, _FontSizeFirst, _FontStyleFirst, _FontUnitFirst);
                    Font fSecond = new Font(_FontNameSecond, _FontSizeSecond, _FontStyleSecond, _FontUnitSecond);
                    SolidBrush sbFirst = new SolidBrush(Color.FromArgb(_FontColorFirst[0], _FontColorFirst[1], _FontColorFirst[2]));
                    SolidBrush sbSecond = new SolidBrush(Color.FromArgb(_FontColorSecond[0], _FontColorSecond[1], _FontColorSecond[2]));

                    Graphics g1First = Graphics.FromImage(new Bitmap(1, 1));
                    Int32 TextWidthInt32First = (Int32)g1First.MeasureString(_TextFirst, fFirst).Width + (_XFirst * 2) + 2;
                    Int32 TextWidthInt32Second = (Int32)g1First.MeasureString(_TextSecond, fSecond).Width + (_XSecond * 2 + 2);

                    System.Drawing.Image i1First;
                    try
                    {
                        i1First = System.Drawing.Image.FromFile(_SourceImageFileName);
                    }
                    catch { return; }

                    Bitmap b2First = new Bitmap(i1First);

                    Bitmap b3First = b2First.Clone(new RectangleF(0, 0, (TextWidthInt32First + TextWidthInt32Second) > b2First.Width ? b2First.Width : (TextWidthInt32First + TextWidthInt32Second), b2First.Height), PixelFormat.DontCare);

                    Graphics g2First = Graphics.FromImage(b3First);

                    g2First.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                    g2First.SmoothingMode = SmoothingMode.AntiAlias;
                    g2First.DrawImage(b3First, _XFirst, _YFirst);

                    //g2First.DrawString(_TextFirst, fFirst, sbFirst, new RectangleF(-3, -3, TextWidthInt32First, b2First.Height), StringFormat.GenericDefault);
                    //g2First.DrawString(_TextSecond, fSecond, sbSecond, new RectangleF(_XSecond + TextWidthInt32First, -3, (TextWidthInt32First + TextWidthInt32Second), b2First.Height), StringFormat.GenericDefault);

                    g2First.DrawString(_TextFirst, fFirst, sbFirst, new RectangleF(-3, 0, TextWidthInt32First, b2First.Height), StringFormat.GenericDefault);
                    g2First.DrawString(_TextSecond, fSecond, sbSecond, new RectangleF(_XSecond + TextWidthInt32First, 0, (TextWidthInt32First + TextWidthInt32Second), b2First.Height), StringFormat.GenericDefault);

                    OctreeQuantizer quantizer = new OctreeQuantizer(255, 8);
                    using (Bitmap BMPQuantized = quantizer.Quantize(b3First))
                    {
                        BMPQuantized.Save(_DestinationImageFileName, System.Drawing.Imaging.ImageFormat.Gif);
                    }
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, String.Empty);
                }
            }


            public static void CreateDynHeaderImage(
                String _Text,
                Int32 _X,
                Int32 _Y,
                Int32 _MaxWidth,
                Int32[] _FontColor,
                String _FontName,
                float _FontSize,
                FontStyle _FontStyle,
                GraphicsUnit _FontUnit,
                String _SourceImageFileName,
                String _DestinationImageFileName)
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::CreateDynHeaderImage]";
                try
                {
                    if (_FontSize.Equals(0))
                        return;

                    // Skapa fonten efter önskad sort och storlek...
                    Font f = new Font(_FontName, _FontSize, _FontStyle, _FontUnit);
                    SolidBrush sb = new SolidBrush(Color.FromArgb(_FontColor[0], _FontColor[1], _FontColor[2]));

                    // Söker av hur bakgrundsbilden ska skapas
                    // om texten exempelvis är bredare än tillåtet 
                    // så ska den radbrytas och bilden blir då högre än vanligt...
                    Graphics g1 = Graphics.FromImage(new Bitmap(1, 1));
                    SizeF _TextWidthInt32 = (SizeF)g1.MeasureString(_Text, f);
                    Int32 TextWidthInt32 = (Int32)_TextWidthInt32.Width;
                    Int32 TextHeigthInt32 = (Int32)_TextWidthInt32.Height;

                    //if (TextWidthInt32 < _MaxWidth)
                    //{
                    //    TextWidthInt32 = _MaxWidth;
                    //}

                    Int32 TextRows = 0;
                    if (TextWidthInt32 <= _MaxWidth)
                        TextRows = 1;
                    else if (TextWidthInt32 > _MaxWidth && TextWidthInt32 < (_MaxWidth * 2))
                        TextRows = 2;
                    else if (TextWidthInt32 > _MaxWidth && TextWidthInt32 < (_MaxWidth * 3))
                        TextRows = 3;
                    else if (TextWidthInt32 > _MaxWidth && TextWidthInt32 < (_MaxWidth * 4))
                        TextRows = 4;
                    else if (TextWidthInt32 > _MaxWidth && TextWidthInt32 < (_MaxWidth * 5))
                        TextRows = 5;
                    else if (TextWidthInt32 > _MaxWidth && TextWidthInt32 < (_MaxWidth * 6))
                        TextRows = 6;
                    else if (TextWidthInt32 > _MaxWidth && TextWidthInt32 < (_MaxWidth * 7))
                        TextRows = 7;
                    else if (TextWidthInt32 > _MaxWidth && TextWidthInt32 < (_MaxWidth * 8))
                        TextRows = 8;
                    else if (TextWidthInt32 > _MaxWidth && TextWidthInt32 < (_MaxWidth * 9))
                        TextRows = 9;

                    System.Drawing.Image i1 = System.Drawing.Image.FromFile(_SourceImageFileName);
                    Bitmap b2 = new Bitmap(1, 1);

                    //Int32 rw = 6;
                    //Int32 rh = 0;
                    //if (TextRows > 1)
                    //{
                    //    rw = 16;
                    //    rh = 5;
                    //}
                    //TextWidthInt32 = (TextWidthInt32 + rw);
                    //TextHeigthInt32 = (TextHeigthInt32 + rh);

                    switch (TextRows)
                    {
                        case 1:
                            b2 = new Bitmap(i1, TextWidthInt32, TextHeigthInt32);
                            break;
                        case 2:
                            b2 = new Bitmap(i1, (TextWidthInt32 / 2) < _MaxWidth ? _MaxWidth : (TextWidthInt32 / 2), TextHeigthInt32 * 2);
                            break;
                        case 3:
                            b2 = new Bitmap(i1, (TextWidthInt32 / 3) < _MaxWidth ? _MaxWidth : (TextWidthInt32 / 3), TextHeigthInt32 * 3);
                            break;
                        case 4:
                            b2 = new Bitmap(i1, (TextWidthInt32 / 4) < _MaxWidth ? _MaxWidth : (TextWidthInt32 / 4), TextHeigthInt32 * 4);
                            break;
                        case 5:
                            b2 = new Bitmap(i1, (TextWidthInt32 / 5) < _MaxWidth ? _MaxWidth : (TextWidthInt32 / 5), TextHeigthInt32 * 5);
                            break;
                        case 6:
                            b2 = new Bitmap(i1, (TextWidthInt32 / 6) < _MaxWidth ? _MaxWidth : (TextWidthInt32 / 6), TextHeigthInt32 * 6);
                            break;
                        case 7:
                            b2 = new Bitmap(i1, (TextWidthInt32 / 7) < _MaxWidth ? _MaxWidth : (TextWidthInt32 / 7), TextHeigthInt32 * 7);
                            break;
                        case 8:
                            b2 = new Bitmap(i1, (TextWidthInt32 / 8) < _MaxWidth ? _MaxWidth : (TextWidthInt32 / 8), TextHeigthInt32 * 8);
                            break;
                        case 9:
                            b2 = new Bitmap(i1, (TextWidthInt32 / 9) < _MaxWidth ? _MaxWidth : (TextWidthInt32 / 9), TextHeigthInt32 * 9);
                            break;
                        default:
                            b2 = new Bitmap(i1, TextWidthInt32, TextHeigthInt32);
                            break;
                    }

                    // Förbered inför text placering på bilden...
                    Graphics g2 = Graphics.FromImage(b2);
                    g2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                    g2.SmoothingMode = SmoothingMode.AntiAlias;
                    g2.DrawImage(b2, b2.Height, b2.Width);
                    int h2 = b2.Height;
                    int w2 = b2.Width;
                    if (_X < 0)
                        w2 = w2 + (Convert.ToInt32(_X.ToString().Replace('-', ' ').Trim()) * 2);
                    if (_Y < 0)
                        h2 = h2 + (Convert.ToInt32(_Y.ToString().Replace('-', ' ').Trim()) * 2);
                    g2.DrawString(_Text, f, sb, new RectangleF(_X, _Y, w2, h2), StringFormat.GenericDefault);

                    //// Skapa varje textrad på bilden...
                    //for (Int32 i = 1; i < (TextRows + 1); i++)
                    //{
                    //    Int32 xx = _X;
                    //    Int32 yy = ((i * (b2.Height / TextRows)) - (b2.Height / TextRows)) + _Y;
                    //    Int32 ww = b2.Width;
                    //    Int32 hh = b2.Height;
                    //    g2.DrawString(_Text, f, sb, new RectangleF(xx, yy, ww, hh), StringFormat.GenericDefault);
                    //}


                    OctreeQuantizer quantizer = new OctreeQuantizer(255, 8);
                    using (Bitmap BMPQuantized = quantizer.Quantize(b2))
                    {
                        BMPQuantized.Save(_DestinationImageFileName, System.Drawing.Imaging.ImageFormat.Gif);
                    }
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, String.Empty);
                }
            }


            public static void CreateTightDynHeaderImage(
                String _Text,
                Int32 _X,
                Int32 _Y,
                Int32 _MaxWidth,
                Int32 _Offset,
                Int32[] _FontColor,
                String _FontName,
                float _FontSize,
                FontStyle _FontStyle,
                GraphicsUnit _FontUnit,
                String _SourceImageFileName,
                String _DestinationImageFileName)              
            
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::CreateTightDynHeaderImage]";
                
                try
                {
                    if (_FontSize.Equals(0))
                        return;

                    // Skapa fonten efter önskad sort och storlek...
                    Font f = new Font(_FontName, _FontSize, _FontStyle, _FontUnit);
                    SolidBrush sb = new SolidBrush(Color.FromArgb(_FontColor[0], _FontColor[1], _FontColor[2]));

                    // Söker av hur bakgrundsbilden ska skapas
                    // om texten exempelvis är bredare än tillåtet 
                    // så ska den radbrytas och bilden blir då högre än vanligt...
                    Graphics g1 = Graphics.FromImage(new Bitmap(1, 1));
                    SizeF _TextWidthInt32 = (SizeF)g1.MeasureString(_Text, f);
                    Int32 TextWidthInt32 = (Int32)_TextWidthInt32.Width;
                    Int32 TextHeigthInt32 = (Int32)_TextWidthInt32.Height;

                    //if (TextWidthInt32 < _MaxWidth)
                    //{
                    //    TextWidthInt32 = _MaxWidth;
                    //}

                    Int32 TextRows = 0;
                    if (TextWidthInt32 <= _MaxWidth)
                        TextRows = 1;
                    else if (TextWidthInt32 > _MaxWidth && TextWidthInt32 < (_MaxWidth * 2))
                        TextRows = 2;
                    else if (TextWidthInt32 > _MaxWidth && TextWidthInt32 < (_MaxWidth * 3))
                        TextRows = 3;
                    else if (TextWidthInt32 > _MaxWidth && TextWidthInt32 < (_MaxWidth * 4))
                        TextRows = 4;
                    else if (TextWidthInt32 > _MaxWidth && TextWidthInt32 < (_MaxWidth * 5))
                        TextRows = 5;
                    else if (TextWidthInt32 > _MaxWidth && TextWidthInt32 < (_MaxWidth * 6))
                        TextRows = 6;
                    else if (TextWidthInt32 > _MaxWidth && TextWidthInt32 < (_MaxWidth * 7))
                        TextRows = 7;
                    else if (TextWidthInt32 > _MaxWidth && TextWidthInt32 < (_MaxWidth * 8))
                        TextRows = 8;
                    else if (TextWidthInt32 > _MaxWidth && TextWidthInt32 < (_MaxWidth * 9))
                        TextRows = 9;

                    System.Drawing.Image i1 = System.Drawing.Image.FromFile(_SourceImageFileName);
                    Bitmap b2 = new Bitmap(1, 1);

                    //Int32 rw = 6;
                    //Int32 rh = 0;
                    //if (TextRows > 1)
                    //{
                    //    rw = 16;
                    //    rh = 5;
                    //}
                    //TextWidthInt32 = (TextWidthInt32 + rw);
                    //TextHeigthInt32 = (TextHeigthInt32 + rh);

                    switch (TextRows)
                    {
                        case 1:
                            b2 = new Bitmap(i1, TextWidthInt32, TextHeigthInt32);
                            break;
                        case 2:
                            b2 = new Bitmap(i1, (TextWidthInt32 / 2) < _MaxWidth ? _MaxWidth : (TextWidthInt32 / 2), TextHeigthInt32 * 2);
                            break;
                        case 3:
                            b2 = new Bitmap(i1, (TextWidthInt32 / 3) < _MaxWidth ? _MaxWidth : (TextWidthInt32 / 3), TextHeigthInt32 * 3);
                            break;
                        case 4:
                            b2 = new Bitmap(i1, (TextWidthInt32 / 4) < _MaxWidth ? _MaxWidth : (TextWidthInt32 / 4), TextHeigthInt32 * 4);
                            break;
                        case 5:
                            b2 = new Bitmap(i1, (TextWidthInt32 / 5) < _MaxWidth ? _MaxWidth : (TextWidthInt32 / 5), TextHeigthInt32 * 5);
                            break;
                        case 6:
                            b2 = new Bitmap(i1, (TextWidthInt32 / 6) < _MaxWidth ? _MaxWidth : (TextWidthInt32 / 6), TextHeigthInt32 * 6);
                            break;
                        case 7:
                            b2 = new Bitmap(i1, (TextWidthInt32 / 7) < _MaxWidth ? _MaxWidth : (TextWidthInt32 / 7), TextHeigthInt32 * 7);
                            break;
                        case 8:
                            b2 = new Bitmap(i1, (TextWidthInt32 / 8) < _MaxWidth ? _MaxWidth : (TextWidthInt32 / 8), TextHeigthInt32 * 8);
                            break;
                        case 9:
                            b2 = new Bitmap(i1, (TextWidthInt32 / 9) < _MaxWidth ? _MaxWidth : (TextWidthInt32 / 9), TextHeigthInt32 * 9);
                            break;
                        default:
                            b2 = new Bitmap(i1, TextWidthInt32, TextHeigthInt32);
                            break;
                    }

                    // Förbered inför text placering på bilden...
                    Graphics g2 = Graphics.FromImage(b2);
                    g2.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                    g2.SmoothingMode = SmoothingMode.AntiAlias;
                    g2.DrawImage(b2, b2.Height, b2.Width - _Offset);
                    int h2 = b2.Height;
                    int w2 = b2.Width;
                    if (_X < 0)
                        w2 = w2 + (Convert.ToInt32(_X.ToString().Replace('-', ' ').Trim()) * 2);
                    if (_Y < 0)
                        h2 = h2 + (Convert.ToInt32(_Y.ToString().Replace('-', ' ').Trim()) * 2);
                    g2.DrawString(_Text, f, sb, new RectangleF(_X, _Y, w2, h2), StringFormat.GenericDefault);

                    //// Skapa varje textrad på bilden...
                    //for (Int32 i = 1; i < (TextRows + 1); i++)
                    //{
                    //    Int32 xx = _X;
                    //    Int32 yy = ((i * (b2.Height / TextRows)) - (b2.Height / TextRows)) + _Y;
                    //    Int32 ww = b2.Width;
                    //    Int32 hh = b2.Height;
                    //    g2.DrawString(_Text, f, sb, new RectangleF(xx, yy, ww, hh), StringFormat.GenericDefault);
                    //}


                    OctreeQuantizer quantizer = new OctreeQuantizer(255, 8);
                    using (Bitmap BMPQuantized = quantizer.Quantize(b2))
                    {
                        BMPQuantized.Save(_DestinationImageFileName, System.Drawing.Imaging.ImageFormat.Gif);
                    }
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, String.Empty);
                }
            }

            public static void CreateFontImage(string _Text, int _Xpos, int _Ypos, int _ImageHeight, int _OffsetWidth, float _FontSize, FontStyle _FontStyle, string _FontPath, Int32[] _FontColor, string _SourceImageFileName, string _DestinationImageFileName)
            {
                string FUNCTIONNAME = CLASSNAME + "[Function::CreateFontImage]";
                try
                {
                    if (_Text != string.Empty)
                    {
                        string font_filename = _FontPath;

                        // Hämtar upp fonterna som ligger lokalt
                        SolidBrush brush = new SolidBrush(Color.FromArgb(_FontColor[0], _FontColor[1], _FontColor[2]));
                        PrivateFontCollection fonts = new PrivateFontCollection();
                        fonts.AddFontFile(font_filename);

                        FontFamily family = fonts.Families[0];
                        Font font = new Font(family, _FontSize, _FontStyle, GraphicsUnit.Pixel);

                        // Hämtar upp bakgrundsbilden           
                        System.Drawing.Image ImgBg = System.Drawing.Image.FromFile(_SourceImageFileName);

                        // Bestämmer bredden på bilden genom att kolla av med fonten
                        Graphics g1 = Graphics.FromImage(new Bitmap(1, 1));

                        SizeF _TextWidthInt32 = (SizeF)g1.MeasureString(_Text, font);
                        Int32 _ImageWidth = (Int32)_TextWidthInt32.Width;

                        // Skapar en ny bild med bakgrundsbilden som bakgrund
                        Bitmap image = new Bitmap(1, 1);
                        image = new Bitmap(ImgBg, (_ImageWidth - _OffsetWidth), _ImageHeight);

                        // Grafik inställningar
                        Graphics graphics = Graphics.FromImage(image);
                        graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        graphics.DrawImage(image, image.Height, (image.Width - _OffsetWidth));
                        graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

                        // Ritar ut Texten
                        graphics.DrawString(_Text, font, brush, new PointF(_Xpos, _Ypos));

                        OctreeQuantizer quantizer = new OctreeQuantizer(255, 8);
                        using (Bitmap BMPQuantized = quantizer.Quantize(image))
                        {
                            BMPQuantized.Save(_DestinationImageFileName, System.Drawing.Imaging.ImageFormat.Gif);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Error.Report(ex, FUNCTIONNAME, String.Empty);
                }
            }

    }



        #endregion public class Image

    }
}
