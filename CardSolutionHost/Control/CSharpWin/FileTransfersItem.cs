﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Threading;
using System.Windows.Forms;
namespace CSharpWin
{
    public class FileTransfersItem : Control
    {
        private Color _baseColor = Color.FromArgb(0xbf, 0xe9, 0xff);
        private Color _borderColor = Color.FromArgb(0x76, 0xd0, 0xe1);
        private ControlState _cancelState;
        private string _fileName;
        private long _fileSize;
        private IFileTransfersItemText _fileTransfersText;
        private System.Drawing.Image _image;
        private int _interval = 0x3e8;
        private Color _progressBarBarColor = Color.FromArgb(0xbf, 0xe9, 0xff);
        private Color _progressBarBorderColor = Color.FromArgb(0x76, 0xd0, 0xe1);
        private Color _progressBarTextColor = Color.FromArgb(0, 0x5f, 0x93);
        private Color _progressBarTrackColor = Color.Gainsboro;
        private int _radius = 8;
        private ControlState _refuseState;
        private CSharpWin.RoundStyle _roundStyle = CSharpWin.RoundStyle.All;
        private ControlState _saveState;
        private ControlState _saveToState;
        private DateTime _startTime = DateTime.Now;
        private FileTransfersItemStyle _style;
        private System.Threading.Timer _timer;
        private long _totalTransfersSize;
        private static readonly object EventCancelButtonClick = new object();
        private static readonly object EventRefuseButtonClick = new object();
        private static readonly object EventSaveButtonClick = new object();
        private static readonly object EventSaveToButtonClick = new object();

        public event EventHandler CancelButtonClick
        {
            add
            {
                base.Events.AddHandler(EventCancelButtonClick, value);
            }
            remove
            {
                base.Events.RemoveHandler(EventCancelButtonClick, value);
            }
        }

        public event EventHandler RefuseButtonClick
        {
            add
            {
                base.Events.AddHandler(EventRefuseButtonClick, value);
            }
            remove
            {
                base.Events.RemoveHandler(EventRefuseButtonClick, value);
            }
        }

        public event EventHandler SaveButtonClick
        {
            add
            {
                base.Events.AddHandler(EventSaveButtonClick, value);
            }
            remove
            {
                base.Events.RemoveHandler(EventSaveButtonClick, value);
            }
        }

        public event EventHandler SaveToButtonClick
        {
            add
            {
                base.Events.AddHandler(EventSaveToButtonClick, value);
            }
            remove
            {
                base.Events.RemoveHandler(EventSaveToButtonClick, value);
            }
        }

        public FileTransfersItem()
        {
            this.SetStyles();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                if (this._timer != null)
                {
                    this._timer.Dispose();
                }
                this._fileTransfersText = null;
            }
        }

        private void DrawGlass(Graphics g, RectangleF glassRect, int alphaCenter, int alphaSurround)
        {
            this.DrawGlass(g, glassRect, Color.White, alphaCenter, alphaSurround);
        }

        private void DrawGlass(Graphics g, RectangleF glassRect, Color glassColor, int alphaCenter, int alphaSurround)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(glassRect);
                using (PathGradientBrush brush = new PathGradientBrush(path))
                {
                    brush.CenterColor = Color.FromArgb(alphaCenter, glassColor);
                    brush.SurroundColors = new Color[] { Color.FromArgb(alphaSurround, glassColor) };
                    brush.CenterPoint = new PointF(glassRect.X + (glassRect.Width / 2f), glassRect.Y + (glassRect.Height / 2f));
                    g.FillPath(brush, path);
                }
            }
        }

        private Color GetColor(Color colorBase, int a, int r, int g, int b)
        {
            int a0 = colorBase.A;
            int r0 = colorBase.R;
            int g0 = colorBase.G;
            int b0 = colorBase.B;
            if ((a + a0) > 0xff)
            {
                a = 0xff;
            }
            else
            {
                a = Math.Max(a + a0, 0);
            }
            if ((r + r0) > 0xff)
            {
                r = 0xff;
            }
            else
            {
                r = Math.Max(r + r0, 0);
            }
            if ((g + g0) > 0xff)
            {
                g = 0xff;
            }
            else
            {
                g = Math.Max(g + g0, 0);
            }
            if ((b + b0) > 0xff)
            {
                b = 0xff;
            }
            else
            {
                b = Math.Max(b + b0, 0);
            }
            return Color.FromArgb(a, r, g, b);
        }

        private string GetSpeedText()
        {
            TimeSpan span = (TimeSpan)(DateTime.Now - this._startTime);
            double speed = ((double)this._totalTransfersSize) / span.TotalSeconds;
            return string.Format("{0}/s", this.GetText(speed));
        }

        private string GetText(double size)
        {
            double result;
            if (size < 1024.0)
            {
                return string.Format("{0} B", size.ToString("f1"));
            }
            if (size < 1048576.0)
            {
                result = size / 1024.0;
                return string.Format("{0} KB", result.ToString("f1"));
            }
            result = size / 1048576.0;
            return string.Format("{0} MB", result.ToString("f1"));
        }

        private Rectangle Inflate(Rectangle rect)
        {
            rect.Inflate(2, 2);
            return rect;
        }

        protected virtual void OnCancelButtonClick(EventArgs e)
        {
            EventHandler handler = base.Events[EventCancelButtonClick] as EventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                Point point = e.Location;
                switch (this._style)
                {
                    case FileTransfersItemStyle.Send:
                    case FileTransfersItemStyle.Receive:
                        if (this.CancelTransfersRect.Contains(point))
                        {
                            this.CancelState = ControlState.Pressed;
                        }
                        break;

                    case FileTransfersItemStyle.ReadyReceive:
                        if (this.SaveRect.Contains(point))
                        {
                            this.SaveState = ControlState.Pressed;
                        }
                        if (this.SaveToRect.Contains(point))
                        {
                            this.SaveToState = ControlState.Pressed;
                        }
                        if (this.RefuseReceiveRect.Contains(point))
                        {
                            this.RefuseState = ControlState.Pressed;
                        }
                        break;
                }
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            switch (this._style)
            {
                case FileTransfersItemStyle.Send:
                case FileTransfersItemStyle.Receive:
                    this.CancelState = ControlState.Normal;
                    break;

                case FileTransfersItemStyle.ReadyReceive:
                    this.SaveState = ControlState.Normal;
                    this.SaveToState = ControlState.Normal;
                    this.RefuseState = ControlState.Normal;
                    break;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Point point = e.Location;
            switch (this._style)
            {
                case FileTransfersItemStyle.Send:
                case FileTransfersItemStyle.Receive:
                    if (!this.CancelTransfersRect.Contains(point))
                    {
                        this.CancelState = ControlState.Normal;
                        return;
                    }
                    this.CancelState = ControlState.Hover;
                    return;

                case FileTransfersItemStyle.ReadyReceive:
                    if (!this.SaveRect.Contains(point))
                    {
                        this.SaveState = ControlState.Normal;
                        break;
                    }
                    this.SaveState = ControlState.Hover;
                    break;

                default:
                    return;
            }
            if (this.SaveToRect.Contains(point))
            {
                this.SaveToState = ControlState.Hover;
            }
            else
            {
                this.SaveToState = ControlState.Normal;
            }
            if (this.RefuseReceiveRect.Contains(point))
            {
                this.RefuseState = ControlState.Hover;
            }
            else
            {
                this.RefuseState = ControlState.Normal;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Left)
            {
                Point point = e.Location;
                switch (this._style)
                {
                    case FileTransfersItemStyle.Send:
                    case FileTransfersItemStyle.Receive:
                        if (!this.CancelTransfersRect.Contains(point))
                        {
                            this.CancelState = ControlState.Normal;
                            return;
                        }
                        this.CancelState = ControlState.Hover;
                        this.OnCancelButtonClick(e);
                        return;

                    case FileTransfersItemStyle.ReadyReceive:
                        if (!this.SaveRect.Contains(point))
                        {
                            this.SaveState = ControlState.Normal;
                        }
                        else
                        {
                            this.SaveState = ControlState.Hover;
                            this.OnSaveButtonClick(e);
                        }
                        if (this.SaveToRect.Contains(point))
                        {
                            this.SaveToState = ControlState.Hover;
                            this.OnSaveToButtonClick(e);
                        }
                        else
                        {
                            this.SaveToState = ControlState.Normal;
                        }
                        if (this.RefuseReceiveRect.Contains(point))
                        {
                            this.RefuseState = ControlState.Hover;
                            this.OnRefuseButtonClick(e);
                        }
                        else
                        {
                            this.RefuseState = ControlState.Normal;
                        }
                        return;
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            if (this.Image != null)
            {
                g.DrawImage(this.Image, this.ImageRect, new Rectangle(Point.Empty, this.Image.Size), GraphicsUnit.Pixel);
            }
            TextFormatFlags flags = TextFormatFlags.EndEllipsis | TextFormatFlags.SingleLine;
            TextRenderer.DrawText(g, this.Text, this.Font, this.TextRect, this.ForeColor, flags);
            TextRenderer.DrawText(g, this.FileName, this.Font, this.FileNameRect, this.ForeColor, flags);
            Rectangle rect = this.ProgressBarRect;
            Color innerBorderColor = Color.FromArgb(200, 0xff, 0xff, 0xff);
            this.RenderBackgroundInternal(g, rect, this._progressBarTrackColor, this._progressBarBorderColor, innerBorderColor, CSharpWin.RoundStyle.All, 8, 0.45f, true, false, LinearGradientMode.Vertical);
            if (this.FileSize != 0L)
            {
                float percent = ((float)this.TotalTransfersSize) / ((float)this.FileSize);
                int width = (int)(rect.Width * percent);
                width = Math.Min(width, rect.Width - 2);
                if (width > 5)
                {
                    Rectangle barRect = new Rectangle(rect.X + 1, rect.Y + 1, width, rect.Height - 2);
                    this.RenderBackgroundInternal(g, barRect, this._progressBarBarColor, this._progressBarBarColor, innerBorderColor, CSharpWin.RoundStyle.All, 8, 0.45f, true, false, LinearGradientMode.Vertical);
                }
                TextRenderer.DrawText(g, percent.ToString("0.0%"), this.Font, rect, this._progressBarTextColor, TextFormatFlags.VerticalCenter | TextFormatFlags.HorizontalCenter);
                string transferSizeText = string.Format("{0}/{1}", this.GetText((double)this._totalTransfersSize), this.GetText((double)this._fileSize));
                TextRenderer.DrawText(g, transferSizeText, this.Font, this.TransfersSizeRect, this.ForeColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
                if (!((this._totalTransfersSize == 0L) || base.DesignMode))
                {
                    TextRenderer.DrawText(g, this.GetSpeedText(), this.Font, this.SpeedRect, this.ForeColor, TextFormatFlags.VerticalCenter);
                }
            }
            flags = TextFormatFlags.EndEllipsis | TextFormatFlags.SingleLine | TextFormatFlags.HorizontalCenter;
            switch (this._style)
            {
                case FileTransfersItemStyle.Send:
                case FileTransfersItemStyle.Receive:
                    if (this.CancelState != ControlState.Normal)
                    {
                        rect = this.CancelTransfersRect;
                        rect.Inflate(2, 2);
                        this.RenderBackgroundInternal(g, rect, this._baseColor, this._borderColor, innerBorderColor, CSharpWin.RoundStyle.All, this._radius, 0.45f, true, true, LinearGradientMode.Vertical);
                    }
                    TextRenderer.DrawText(g, this.FileTransfersText.CancelTransfers, this.Font, this.CancelTransfersRect, this.ForeColor, flags);
                    break;

                case FileTransfersItemStyle.ReadyReceive:
                    {
                        bool drawBack = false;
                        if (this.SaveState != ControlState.Normal)
                        {
                            rect = this.SaveRect;
                            rect.Inflate(2, 2);
                            drawBack = true;
                        }
                        if (this.SaveToState != ControlState.Normal)
                        {
                            rect = this.SaveToRect;
                            rect.Inflate(2, 2);
                            drawBack = true;
                        }
                        if (this.RefuseState != ControlState.Normal)
                        {
                            rect = this.RefuseReceiveRect;
                            rect.Inflate(2, 2);
                            drawBack = true;
                        }
                        if (drawBack)
                        {
                            this.RenderBackgroundInternal(g, rect, this._baseColor, this._borderColor, innerBorderColor, CSharpWin.RoundStyle.All, this._radius, 0.45f, true, true, LinearGradientMode.Vertical);
                        }
                        TextRenderer.DrawText(g, this.FileTransfersText.RefuseReceive, this.Font, this.RefuseReceiveRect, this.ForeColor, flags);
                        TextRenderer.DrawText(g, this.FileTransfersText.SaveTo, this.Font, this.SaveToRect, this.ForeColor, flags);
                        TextRenderer.DrawText(g, this.FileTransfersText.Save, this.Font, this.SaveRect, this.ForeColor, flags);
                        break;
                    }
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            Graphics g = e.Graphics;
            Rectangle rect = base.ClientRectangle;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            rect.Inflate(-1, -1);
            this.RenderBackgroundInternal(g, rect, this._baseColor, this._borderColor, Color.FromArgb(200, 0xff, 0xff), this._roundStyle, this._radius, 0.45f, true, false, LinearGradientMode.Vertical);
        }

        protected virtual void OnRefuseButtonClick(EventArgs e)
        {
            EventHandler handler = base.Events[EventRefuseButtonClick] as EventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnSaveButtonClick(EventArgs e)
        {
            EventHandler handler = base.Events[EventSaveButtonClick] as EventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnSaveToButtonClick(EventArgs e)
        {
            EventHandler handler = base.Events[EventSaveToButtonClick] as EventHandler;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        internal void RenderBackgroundInternal(Graphics g, Rectangle rect, Color baseColor, Color borderColor, Color innerBorderColor, CSharpWin.RoundStyle style, int roundWidth, float basePosition, bool drawBorder, bool drawGlass, LinearGradientMode mode)
        {
            if (drawBorder)
            {
                rect.Width--;
                rect.Height--;
            }
            if ((rect.Width > 0) && (rect.Height > 0))
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(rect, Color.Transparent, Color.Transparent, mode))
                {
                    Rectangle rectTop;
                    SolidBrush brushAlpha;
                    RectangleF glassRect;
                    Pen pen;
                    Color[] colors = new Color[] { this.GetColor(baseColor, 0, 0x23, 0x18, 9), this.GetColor(baseColor, 0, 13, 8, 3), baseColor, this.GetColor(baseColor, 0, 0x44, 0x45, 0x36) };
                    ColorBlend blend = new ColorBlend();
                    float[] arrays = new float[4];
                    arrays[1] = basePosition;
                    arrays[2] = basePosition + 0.05f;
                    arrays[3] = 1f;
                    blend.Positions = arrays;
                    blend.Colors = colors;
                    brush.InterpolationColors = blend;
                    if (style != CSharpWin.RoundStyle.None)
                    {
                        GraphicsPath path;
                        using (path = GraphicsPathHelper.CreatePath(rect, roundWidth, style, false))
                        {
                            g.FillPath(brush, path);
                        }
                        if (baseColor.A > 80)
                        {
                            rectTop = rect;
                            if (mode == LinearGradientMode.Vertical)
                            {
                                rectTop.Height = (int)(rectTop.Height * basePosition);
                            }
                            else
                            {
                                rectTop.Width = (int)(rect.Width * basePosition);
                            }
                            using (GraphicsPath pathTop = GraphicsPathHelper.CreatePath(rectTop, roundWidth, CSharpWin.RoundStyle.Top, false))
                            {
                                using (brushAlpha = new SolidBrush(Color.FromArgb(80, 0xff, 0xff, 0xff)))
                                {
                                    g.FillPath(brushAlpha, pathTop);
                                }
                            }
                        }
                        if (drawGlass)
                        {
                            glassRect = rect;
                            if (mode == LinearGradientMode.Vertical)
                            {
                                glassRect.Y = rect.Y + (rect.Height * basePosition);
                                glassRect.Height = (rect.Height - (rect.Height * basePosition)) * 2f;
                            }
                            else
                            {
                                glassRect.X = rect.X + (rect.Width * basePosition);
                                glassRect.Width = (rect.Width - (rect.Width * basePosition)) * 2f;
                            }
                            this.DrawGlass(g, glassRect, 170, 0);
                        }
                        if (drawBorder)
                        {
                            using (path = GraphicsPathHelper.CreatePath(rect, roundWidth, style, false))
                            {
                                using (pen = new Pen(borderColor))
                                {
                                    g.DrawPath(pen, path);
                                }
                            }
                            rect.Inflate(-1, -1);
                            using (path = GraphicsPathHelper.CreatePath(rect, roundWidth, style, false))
                            {
                                using (pen = new Pen(innerBorderColor))
                                {
                                    g.DrawPath(pen, path);
                                }
                            }
                        }
                    }
                    else
                    {
                        g.FillRectangle(brush, rect);
                        if (baseColor.A > 80)
                        {
                            rectTop = rect;
                            if (mode == LinearGradientMode.Vertical)
                            {
                                rectTop.Height = (int)(rectTop.Height * basePosition);
                            }
                            else
                            {
                                rectTop.Width = (int)(rect.Width * basePosition);
                            }
                            using (brushAlpha = new SolidBrush(Color.FromArgb(80, 0xff, 0xff, 0xff)))
                            {
                                g.FillRectangle(brushAlpha, rectTop);
                            }
                        }
                        if (drawGlass)
                        {
                            glassRect = rect;
                            if (mode == LinearGradientMode.Vertical)
                            {
                                glassRect.Y = rect.Y + (rect.Height * basePosition);
                                glassRect.Height = (rect.Height - (rect.Height * basePosition)) * 2f;
                            }
                            else
                            {
                                glassRect.X = rect.X + (rect.Width * basePosition);
                                glassRect.Width = (rect.Width - (rect.Width * basePosition)) * 2f;
                            }
                            this.DrawGlass(g, glassRect, 200, 0);
                        }
                        if (drawBorder)
                        {
                            using (pen = new Pen(borderColor))
                            {
                                g.DrawRectangle(pen, rect);
                            }
                            rect.Inflate(-1, -1);
                            using (pen = new Pen(innerBorderColor))
                            {
                                g.DrawRectangle(pen, rect);
                            }
                        }
                    }
                }
            }
        }

        private void SetStyles()
        {
            base.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.FixedHeight | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            base.SetStyle(ControlStyles.Opaque, false);
            base.UpdateStyles();
        }

        public void Start()
        {
            this._startTime = DateTime.Now;
            this.Timer.Change(this._interval, this._interval);
        }

        [DefaultValue(typeof(Color), "191, 233, 255")]
        public Color BaseColor
        {
            get
            {
                return this._baseColor;
            }
            set
            {
                this._baseColor = value;
                base.Invalidate();
            }
        }

        [DefaultValue(typeof(Color), "118, 208, 225")]
        public Color BorderColor
        {
            get
            {
                return this._borderColor;
            }
            set
            {
                this._borderColor = value;
                base.Invalidate();
            }
        }

        private ControlState CancelState
        {
            get
            {
                return this._cancelState;
            }
            set
            {
                if (this._cancelState != value)
                {
                    this._cancelState = value;
                    base.Invalidate(this.Inflate(this.CancelTransfersRect));
                }
            }
        }

        internal Rectangle CancelTransfersRect
        {
            get
            {
                Size size = TextRenderer.MeasureText(this.FileTransfersText.CancelTransfers, this.Font);
                return new Rectangle((base.Width - size.Width) - 7, 0x4f, size.Width, size.Height);
            }
        }

        protected override Size DefaultSize
        {
            get
            {
                return new Size(200, 0x61);
            }
        }

        [DefaultValue("")]
        public string FileName
        {
            get
            {
                return this._fileName;
            }
            set
            {
                this._fileName = value;
                base.Invalidate();
            }
        }

        internal Rectangle FileNameRect
        {
            get
            {
                return new Rectangle(0x2b, 0x16, base.Width - 0x31, 0x10);
            }
        }

        [DefaultValue(0)]
        public long FileSize
        {
            get
            {
                return this._fileSize;
            }
            set
            {
                this._fileSize = value;
                base.Invalidate();
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IFileTransfersItemText FileTransfersText
        {
            get
            {
                if (this._fileTransfersText == null)
                {
                    this._fileTransfersText = new FileTransfersItemText();
                }
                return this._fileTransfersText;
            }
            set
            {
                this._fileTransfersText = value;
                base.Invalidate();
            }
        }

        [DefaultValue(typeof(Icon), "null")]
        public System.Drawing.Image Image
        {
            get
            {
                return this._image;
            }
            set
            {
                this._image = value;
                base.Invalidate();
            }
        }

        internal Rectangle ImageRect
        {
            get
            {
                return new Rectangle(6, 6, 0x20, 0x20);
            }
        }

        [DefaultValue(0x3e8)]
        public int Interval
        {
            get
            {
                return this._interval;
            }
            set
            {
                this._interval = value;
            }
        }

        [DefaultValue(typeof(Color), "191, 233, 255")]
        public Color ProgressBarBarColor
        {
            get
            {
                return this._progressBarBarColor;
            }
            set
            {
                this._progressBarBarColor = value;
                base.Invalidate(this.ProgressBarRect);
            }
        }

        [DefaultValue(typeof(Color), "118, 208, 225")]
        public Color ProgressBarBorderColor
        {
            get
            {
                return this._progressBarBorderColor;
            }
            set
            {
                this._progressBarBorderColor = value;
                base.Invalidate(this.ProgressBarRect);
            }
        }

        internal Rectangle ProgressBarRect
        {
            get
            {
                return new Rectangle(6, 0x29, base.Width - 12, 0x10);
            }
        }

        [DefaultValue(typeof(Color), "0, 95, 147")]
        public Color ProgressBarTextColor
        {
            get
            {
                return this._progressBarTextColor;
            }
            set
            {
                this._progressBarTextColor = value;
                base.Invalidate(this.ProgressBarRect);
            }
        }

        [DefaultValue(typeof(Color), "Gainsboro")]
        public Color ProgressBarTrackColor
        {
            get
            {
                return this._progressBarTrackColor;
            }
            set
            {
                this._progressBarTrackColor = value;
                base.Invalidate(this.ProgressBarRect);
            }
        }

        [DefaultValue(8)]
        public int Radius
        {
            get
            {
                return this._radius;
            }
            set
            {
                if (this._radius != value)
                {
                    this._radius = (value < 4) ? 4 : value;
                    base.Invalidate();
                }
            }
        }

        internal Rectangle RefuseReceiveRect
        {
            get
            {
                Size size = TextRenderer.MeasureText(this.FileTransfersText.RefuseReceive, this.Font);
                return new Rectangle((base.Width - size.Width) - 7, 0x4f, size.Width, size.Height);
            }
        }

        private ControlState RefuseState
        {
            get
            {
                return this._refuseState;
            }
            set
            {
                if (this._refuseState != value)
                {
                    this._refuseState = value;
                    base.Invalidate(this.Inflate(this.RefuseReceiveRect));
                }
            }
        }

        [DefaultValue(typeof(CSharpWin.RoundStyle), "1")]
        public CSharpWin.RoundStyle RoundStyle
        {
            get
            {
                return this._roundStyle;
            }
            set
            {
                if (this._roundStyle != value)
                {
                    this._roundStyle = value;
                    base.Invalidate();
                }
            }
        }

        internal Rectangle SaveRect
        {
            get
            {
                Size size = TextRenderer.MeasureText(this.FileTransfersText.Save, this.Font);
                return new Rectangle((this.SaveToRect.X - size.Width) - 20, 0x4f, size.Width, size.Height);
            }
        }

        private ControlState SaveState
        {
            get
            {
                return this._saveState;
            }
            set
            {
                if (this._saveState != value)
                {
                    this._saveState = value;
                    base.Invalidate(this.Inflate(this.SaveRect));
                }
            }
        }

        internal Rectangle SaveToRect
        {
            get
            {
                Size size = TextRenderer.MeasureText(this.FileTransfersText.SaveTo, this.Font);
                return new Rectangle((this.RefuseReceiveRect.X - size.Width) - 20, 0x4f, size.Width, size.Height);
            }
        }

        private ControlState SaveToState
        {
            get
            {
                return this._saveToState;
            }
            set
            {
                if (this._saveToState != value)
                {
                    this._saveToState = value;
                    base.Invalidate(this.Inflate(this.SaveToRect));
                }
            }
        }

        internal Rectangle SpeedRect
        {
            get
            {
                return new Rectangle(6, 60, (base.Width / 2) - 8, 0x10);
            }
        }

        [DefaultValue(typeof(FileTransfersItemStyle), "0")]
        public FileTransfersItemStyle Style
        {
            get
            {
                return this._style;
            }
            set
            {
                this._style = value;
                base.Invalidate();
            }
        }

        internal Rectangle TextRect
        {
            get
            {
                return new Rectangle(0x2b, 6, base.Width - 0x31, 0x10);
            }
        }

        internal System.Threading.Timer Timer
        {
            get
            {
                if (this._timer == null)
                {
                    this._timer = new System.Threading.Timer(delegate(object obj)
                    {
                        if (!base.Disposing)
                        {
                            base.BeginInvoke(new MethodInvoker(() =>
                            {
                                base.Invalidate(this.SpeedRect);
                            }));
                        }
                    }, null, -1, this._interval);
                }
                return this._timer;
            }
        }

        [DefaultValue(0)]
        public long TotalTransfersSize
        {
            get
            {
                return this._totalTransfersSize;
            }
            set
            {
                if (this._totalTransfersSize != value)
                {
                    if (value > this._fileSize)
                    {
                        this._totalTransfersSize = this._fileSize;
                    }
                    else
                    {
                        this._totalTransfersSize = value;
                    }
                    base.Invalidate(this.ProgressBarRect);
                    base.Invalidate(this.TransfersSizeRect);
                }
            }
        }

        internal Rectangle TransfersSizeRect
        {
            get
            {
                return new Rectangle(base.Width / 2, 60, (base.Width / 2) - 6, 0x10);
            }
        }
    }
}

