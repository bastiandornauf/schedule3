/* Developed by Ertan Tike (ertant@rdgnet.org) */

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Calendar
{
    public static class Cal
    {
        public static int Minutes
        {
            get { return 15; }
        }
        public static int Part
        {
            get { return (60 / Minutes); }
        }
    }

    public class DayView : Control
    {
        #region Variables

        private TextBox editbox;
        private VScrollBar scrollbar;
        private DrawTool drawTool;
        private SelectionTool selectionTool;
        private int allDayEventsHeaderHeight = 20;

        private DateTime workStart;
        private DateTime workEnd;
        private int firstHourMark;
        private int lastHourMark;
        private int startMiddayMark;
        private int endMiddayMark;

        private bool drawMarks = true;
        private bool drawMiddayMarks = true;

        private bool startWeekday = false;
        private DayOfWeek firstWeekday = DayOfWeek.Monday;
        public System.Windows.Forms.Cursor userCursor = null; 

        #endregion

        #region Constants

        private int hourLabelWidth = 50;
        private int hourLabelIndent = 2;
        private int dayHeadersHeight = 20;
        private int appointmentGripWidth = 5;
        private int horizontalAppointmentHeight = 20;

        #endregion

        #region c.tor

        public DayView()
        {
            scrollbar = new VScrollBar();
            editbox = new TextBox();
            drawTool = new DrawTool();
            selectionTool = new SelectionTool();
            selectionTool.Complete += new EventHandler(selectionTool_Complete);

            SetUpControls();
            AddHandler();

            this.Controls.Add(scrollbar);
            this.Controls.Add(editbox);
            this.Renderer = new Office12Renderer();
            
        }

        private void AddHandler()
        {
            scrollbar.Scroll += new ScrollEventHandler(scrollbar_Scroll);
            editbox.KeyUp += new KeyEventHandler(editbox_KeyUp);

        }

        private void SetUpControls()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.Selectable, true);

            scrollbar.SmallChange = quarterHourHeight;
            scrollbar.LargeChange = quarterHourHeight * Cal.Part;
            scrollbar.Minimum = 0;
            scrollbar.Maximum = quarterHourHeight * Cal.Part * 24;
            scrollbar.Dock = DockStyle.Right;
            scrollbar.Visible = allowScroll;
            AdjustScrollbar();
            scrollbar.Value = (startHour * Cal.Part * quarterHourHeight);


            editbox.Multiline = true;
            editbox.Visible = false;
            editbox.BorderStyle = BorderStyle.None;
            editbox.Margin = Padding.Empty;


            drawTool.DayView = this;

            selectionTool.DayView = this;

            activeTool = drawTool;

            UpdateWorkingHours();

            SetMarks(
                new DateTime(2007, 01, 22, 8, 0, 0),
                new DateTime(2007, 01, 22, 21, 30, 0),
                new DateTime(2007, 01, 22, 12, 30, 0),
                new DateTime(2007, 01, 22, 15, 0, 0));

            //Default quarterHourHeight = 72/Cal.Part
            quarterHourHeight = 60 / Cal.Part;

        }

        public void Reset()
        {
            SetUpControls();
            Invalidate();
        }

        #endregion

        #region Properties

        private int quarterHourHeight = 50;

        public bool StartWeekday
        {
            get { return startWeekday; }
            set { startWeekday = value; }
        }

        public DayOfWeek FirstWeekday
        {
            get { return firstWeekday; }
            set
            {
                   firstWeekday = value;
            }
        }

        public void ResetScrollbar()
        {
            scrollbar.Value = (startHour * Cal.Part * quarterHourHeight);
            this.Update();
        }

        public bool DrawMarks
        {
            get { return drawMarks; }
            set { drawMarks = value; }
        }
        public bool DrawMiddayMarks
        {
            get { return drawMiddayMarks; }
            set { drawMiddayMarks = value; }
        }

        public int FirstHourMark
        {
            get { return firstHourMark; }
            set { firstHourMark = value; }
        }
        public int LastHourMark
        {
            get { return lastHourMark; }
            set { lastHourMark = value; }
        }
        public int StartMiddayMark
        {
            get { return startMiddayMark; }
            set { startMiddayMark = value; }
        }
        public int EndMiddayMark
        {
            get { return endMiddayMark; }
            set { endMiddayMark = value; }
        }

        
        [System.ComponentModel.DefaultValue(18)]
        public int HalfHourHeight
        {
            get
            {
                return quarterHourHeight;
            }
            set
            {
                quarterHourHeight = value;
                OnHalfHourHeightChanged();
            }
        }

        private void OnHalfHourHeightChanged()
        {
            AdjustScrollbar();
            Invalidate();
        }

        private AbstractRenderer renderer;

        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public AbstractRenderer Renderer
        {
            get
            {
                return renderer;
            }
            set
            {
                renderer = value;
                OnRendererChanged();
            }
        }

        private void OnRendererChanged()
        {
            this.Font = renderer.BaseFont;
            this.Invalidate();
        }

        private int daysToShow = 1;

        [System.ComponentModel.DefaultValue(1)]
        public int DaysToShow
        {
            get
            {
                return daysToShow;
            }
            set
            {
                daysToShow = value;
                OnDaysToShowChanged();
            }
        }

        protected virtual void OnDaysToShowChanged()
        {
            if (this.CurrentlyEditing)
                FinishEditing(true);

            Invalidate();
        }

        private SelectionType selection;

        [System.ComponentModel.Browsable(false)]
        public SelectionType Selection
        {
            get
            {
                return selection;
            }
        }

        private DateTime startDate;

        public DateTime StartDate
        {
            get
            {
                return startDate;
            }
            set
            {
                startDate = value;

                if( startWeekday ) 
                {
                    while (startDate.DayOfWeek != firstWeekday)
                        startDate = startDate.AddDays(-1);                       
                }                
                
                OnStartDateChanged();
            }
        }

        protected virtual void OnStartDateChanged()
        {
            startDate = startDate.Date;

            selectedAppointment = null;
            selectedAppointmentIsNew = false;
            selection = SelectionType.DateRange;

            Invalidate();
        }

        private int startHour = 8;

        [System.ComponentModel.DefaultValue(8)]
        public int StartHour
        {
            get
            {
                return startHour;
            }
            set
            {
                startHour = value;
                OnStartHourChanged();
            }
        }

        protected virtual void OnStartHourChanged()
        {
            scrollbar.Value = (startHour * Cal.Part * quarterHourHeight);

            Invalidate();
        }

        private DVAppointment selectedAppointment;

        [System.ComponentModel.Browsable(false)]
        public DVAppointment SelectedAppointment
        {
            get { return selectedAppointment; }
        }

        private DateTime selectionStart;

        public DateTime SelectionStart
        {
            get { return selectionStart; }
            set { selectionStart = value; }
        }

        private DateTime selectionEnd;

        public DateTime SelectionEnd
        {
            get { return selectionEnd; }
            set { selectionEnd = value; }
        }

        private ITool activeTool;

        [System.ComponentModel.Browsable(false)]
        public ITool ActiveTool
        {
            get { return activeTool; }
            set { activeTool = value; }
        }

        [System.ComponentModel.Browsable(false)]
        public bool CurrentlyEditing
        {
            get
            {
                return editbox.Visible;
            }
        }

        private int workingHourStart = 7;

        [System.ComponentModel.DefaultValue(7)]
        public int WorkingHourStart
        {
            get
            {
                return workingHourStart;
            }
            set
            {
                workingHourStart = value;
                UpdateWorkingHours();
            }
        }

        private int workingMinuteStart = 30;

        [System.ComponentModel.DefaultValue(30)]
        public int WorkingMinuteStart
        {
            get
            {
                return workingMinuteStart;
            }
            set
            {
                workingMinuteStart = value;
                UpdateWorkingHours();
            }
        }

        private int workingHourEnd = 22;

        [System.ComponentModel.DefaultValue(22)]
        public int WorkingHourEnd
        {
            get
            {
                return workingHourEnd;
            }
            set
            {
                workingHourEnd = value;
                UpdateWorkingHours();
            }
        }

        private int workingMinuteEnd = 30;

        [System.ComponentModel.DefaultValue(30)]
        public int WorkingMinuteEnd
        {
            get { return workingMinuteEnd; }
            set
            {
                workingMinuteEnd = value;
                UpdateWorkingHours();
            }
        }

        private void UpdateWorkingHours()
        {
            workStart = new DateTime(1, 1, 1, workingHourStart, workingMinuteStart, 0);
            workEnd = new DateTime(1, 1, 1, workingHourEnd, workingMinuteEnd, 0);

            Invalidate();
        }

        bool selectedAppointmentIsNew;

        public bool SelectedAppointmentIsNew
        {
            get
            {
                return selectedAppointmentIsNew;
            }
        }

        private bool allowScroll = true;

        [System.ComponentModel.DefaultValue(true)]
        public bool AllowScroll
        {
            get
            {
                return allowScroll;
            }
            set
            {
                allowScroll = value;
            }
        }

        private bool allowInplaceEditing = true;

        [System.ComponentModel.DefaultValue(true)]
        public bool AllowInplaceEditing
        {
            get
            {
                return allowInplaceEditing;
            }
            set
            {
                allowInplaceEditing = value;
            }
        }

        private bool allowNew = true;

        [System.ComponentModel.DefaultValue(true)]
        public bool AllowNew
        {
            get
            {
                return allowNew;
            }
            set
            {
                allowNew = value;
            }
        }

        #endregion

        private int HeaderHeight
        {
            get
            {
                return dayHeadersHeight + allDayEventsHeaderHeight;
            }
        }

        #region Event Handlers

        void editbox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                FinishEditing(true);
            }
            else if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                FinishEditing(false);
            }
        }

        void selectionTool_Complete(object sender, EventArgs e)
        {
            if (selectedAppointment != null)
            {
                System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(EnterEditMode));
            }
        }

        void scrollbar_Scroll(object sender, ScrollEventArgs e)
        {
            Invalidate();

            if (editbox.Visible)
                //scroll text box too
                editbox.Top += e.OldValue - e.NewValue;
        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, width, height, specified);
            AdjustScrollbar();
        }

        private void AdjustScrollbar()
        {
            scrollbar.Maximum = (Cal.Part * quarterHourHeight * 25) - this.Height + this.HeaderHeight;
            scrollbar.Minimum = 0;
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            // Flicker free
        }



        protected override void OnMouseDown(MouseEventArgs e)
        {
            // Capture focus
            this.Focus();

            if (CurrentlyEditing)
            {
                FinishEditing(false);
            }

            if (selectedAppointmentIsNew)
            {
                RaiseNewAppointment();
            }

            ITool newTool = null;

            DVAppointment appointment = GetAppointmentAt(e.X, e.Y);

            if (appointment == null)
            {
                if (selectedAppointment != null)
                {
                    selectedAppointment = null;
                    Invalidate();
                }

                newTool = drawTool;
                selection = SelectionType.DateRange;
            }
            else
            {
                newTool = selectionTool;
                selectedAppointment = appointment;
                selection = SelectionType.Appointment;

                Invalidate();
            }

            if (activeTool != null)
            {
                activeTool.MouseDown(e);
            }

            if ((activeTool != newTool) && (newTool != null))
            {
                newTool.Reset();
                newTool.MouseDown(e);
            }

            activeTool = newTool;

            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (activeTool != null)
                activeTool.MouseMove(e);

            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (activeTool != null)
                activeTool.MouseUp(e);

            base.OnMouseUp(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            int newScrollValue;

            if (e.Delta < 0)
            {//mouse wheel scroll down
                newScrollValue = this.scrollbar.Value + this.scrollbar.SmallChange;

                if (newScrollValue < this.scrollbar.Maximum)
                    this.scrollbar.Value = newScrollValue;
                else
                    this.scrollbar.Value = this.scrollbar.Maximum;
            }
            else
            {//mouse wheel scroll up
                newScrollValue = this.scrollbar.Value - this.scrollbar.SmallChange;

                if (newScrollValue > this.scrollbar.Minimum)
                    this.scrollbar.Value = newScrollValue;
                else
                    this.scrollbar.Value = this.scrollbar.Minimum;
            }

            this.Invalidate();
        }

        System.Collections.Hashtable cachedAppointments = new System.Collections.Hashtable();

        protected virtual void OnResolveAppointments(ResolveAppointmentsEventArgs args)
        {
#if DEBUG
            System.Diagnostics.Debug.WriteLine("Resolve app");
#endif
            if (ResolveAppointments != null)
                ResolveAppointments(this, args);

            this.allDayEventsHeaderHeight = 0;

            // cache resolved appointments in hashtable by days.
            cachedAppointments.Clear();

            if ((selectedAppointmentIsNew) && (selectedAppointment != null))
            {
                if ((selectedAppointment.StartDate > args.StartDate) && (selectedAppointment.StartDate < args.EndDate))
                {
                    args.Appointments.Add(selectedAppointment);
                }
            }

            foreach (DVAppointment appointment in args.Appointments)
            {
                int key = -1;
                AppointmentList list;

                if (appointment.StartDate.Day == appointment.EndDate.Day)
                {
                    key = appointment.StartDate.Day;
                    appointment.allDayEvent = true;
                }
                else
                {
                    key = -1;
                    appointment.allDayEvent = true;

                    this.allDayEventsHeaderHeight += horizontalAppointmentHeight;
                }

                list = (AppointmentList)cachedAppointments[key];

                if (list == null)
                {
                    list = new AppointmentList();
                    cachedAppointments[key] = list;
                }

                if (appointment.StartDate.Day != appointment.EndDate.Day)
                {
                    //throw new Exception("Kann nur Appointments innerhalb eines Tages verwalten!");
                    appointment.EndDate = new DateTime(appointment.StartDate.Year, appointment.StartDate.Month, appointment.StartDate.Day, appointment.EndDate.Hour, appointment.EndDate.Minute, 0);
                    if (appointment.StartDate > appointment.EndDate)
                    {
                        DateTime mem = appointment.StartDate;
                        appointment.StartDate = appointment.EndDate;
                        appointment.EndDate = mem;
                    }
                    // böser Workaround Ende
                }
                else
                    list.Add(appointment);
            }
        }

        internal void RaiseSelectionChanged(EventArgs e)
        {
            if (SelectionChanged != null)
                SelectionChanged(this, e);
        }

        internal void RaiseAppointmentMove(AppointmentEventArgs e)
        {
            if (AppoinmentMove != null)
                AppoinmentMove(this, e);
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if ((allowNew) && char.IsLetterOrDigit(e.KeyChar))
            {
                if ((this.Selection == SelectionType.DateRange))
                {
                    if (!selectedAppointmentIsNew)
                        EnterNewAppointmentMode(e.KeyChar);
                }
            }
        }

        private void EnterNewAppointmentMode(char key)
        {
            DVAppointment appointment = new DVAppointment();
            appointment.StartDate = selectionStart;
            appointment.EndDate = selectionEnd;
            // TODO hier könnte man Termin korrekt machen
            appointment.Title = key.ToString();

            selectedAppointment = appointment;
            selectedAppointmentIsNew = true;

            activeTool = selectionTool;

            Invalidate();

            System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(EnterEditMode));
        }

        private delegate void StartEditModeDelegate(object state);

        private void EnterEditMode(object state)
        {            
            if (!allowInplaceEditing)
                return;

            if (this.InvokeRequired)
            {
                DVAppointment selectedApp = selectedAppointment;

                System.Threading.Thread.Sleep(200);

                if (selectedApp == selectedAppointment)
                    this.Invoke(new StartEditModeDelegate(EnterEditMode), state);
            }
            else
            {
                StartEditing();
            }
        }

        internal void RaiseNewAppointment()
        {
            NewAppointmentEventArgs args = new NewAppointmentEventArgs(selectedAppointment.Title, selectedAppointment.StartDate, selectedAppointment.EndDate);

            if (NewAppointment != null)
            {
                NewAppointment(this, args);
            }

            selectedAppointment = null;
            selectedAppointmentIsNew = false;

            Invalidate();
        }

        #endregion

        #region Public Methods

        public void SetMarks(DateTime start, DateTime end)
        {
            drawMarks = true;
            drawMiddayMarks = false;
            firstHourMark= GetHourFromDate(start);            
            lastHourMark = GetHourFromDate(end);

            workEnd = end;
            workStart = start;
        }
        public void SetMarks(DateTime start, DateTime end, DateTime middayStart, DateTime middayEnd)
        {
            drawMarks = true;
            drawMiddayMarks = true;
            firstHourMark = GetHourFromDate(start);
            lastHourMark= GetHourFromDate(end);
            startMiddayMark = GetHourFromDate(middayStart);
            endMiddayMark = GetHourFromDate(middayEnd);

            workEnd = end;
            workStart = start;

        }
        private int GetHourFromDate(DateTime d)
        {
            int std = d.Hour;
            int min = d.Minute;
            int hour = std * Cal.Part;
            hour += (int)Math.Round((double)min / (double)Cal.Minutes, 0);

            return hour;
        }
        public void StartEditing()
        {
            if (!selectedAppointment.InPlaceEditable)
            {
                // Termin erlaubt InPlace-Editing nicht
                // ggfs. spez. Delegat aufrufen???
            } else
            if (!selectedAppointment.Locked && appointmentViews.ContainsKey(selectedAppointment))
            {
                Rectangle editBounds = appointmentViews[selectedAppointment].Rectangle;

                editBounds.Inflate(-3, -3);
                editBounds.X += appointmentGripWidth - 2;
                editBounds.Width -= appointmentGripWidth - 5;

                editbox.Bounds = editBounds;
                editbox.Text = selectedAppointment.Title;
                editbox.Visible = true;
                editbox.SelectionStart = editbox.Text.Length;
                editbox.SelectionLength = 0;
                editbox.Font = new Font("Trebuchet MS", 8);

                editbox.Focus();
            }
        }

        public void FinishEditing(bool cancel)
        {
            editbox.Visible = false;

            if (!cancel)
            {
                if (selectedAppointment != null)
                {
                    selectedAppointment.Title = editbox.Text;
                }
            }
            else
            {
                if (selectedAppointmentIsNew)
                {
                    selectedAppointment = null;
                    selectedAppointmentIsNew = false;
                }
            }

            
            Invalidate();
            this.Focus();


        }

        public DateTime GetTimeAt(int x, int y)
        {
            int dayWidth = (this.Width - (scrollbar.Width + hourLabelWidth)) / daysToShow;

            int hour = (y - this.HeaderHeight + scrollbar.Value) / quarterHourHeight;
            x -= hourLabelWidth;

            DateTime date = startDate;

            date = date.Date;
            date = date.AddDays(x / dayWidth);

            if ((hour > 0) && (hour < 24 * Cal.Part))
                date = date.AddMinutes((hour * Cal.Minutes));

            return date;
        }

        public DVAppointment GetAppointmentAt(int x, int y)
        {
            if (y < this.HeaderHeight)
                return null;

            foreach (AppointmentView view in appointmentViews.Values)
                if (view.Rectangle.Contains(x, y))
                    return view.Appointment;

            return null;
        }

        #endregion

        #region Drawing Methods

        protected override void OnPaint(PaintEventArgs e)
        {
            // resolve appointments on visible date range.
            ResolveAppointmentsEventArgs args = new ResolveAppointmentsEventArgs(this.StartDate, this.StartDate.AddDays(daysToShow));
            OnResolveAppointments(args);

            using (SolidBrush backBrush = new SolidBrush(renderer.BackColor))
                e.Graphics.FillRectangle(backBrush, this.ClientRectangle);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Calculate visible rectangle
            Rectangle rectangle = new Rectangle(0, 0, this.Width - scrollbar.Width, this.Height);

            Rectangle hourLabelRectangle = rectangle;

            hourLabelRectangle.Y += this.HeaderHeight;

            DrawHourLabels(e, hourLabelRectangle);

            Rectangle daysRectangle = rectangle;
            daysRectangle.X += hourLabelWidth;
            daysRectangle.Y += this.HeaderHeight;
            daysRectangle.Width -= hourLabelWidth;

            if (e.ClipRectangle.IntersectsWith(daysRectangle))
            {
                DrawDays(e, daysRectangle);
            }

            Rectangle headerRectangle = rectangle;

            headerRectangle.X += hourLabelWidth;
            headerRectangle.Width -= hourLabelWidth;
            headerRectangle.Height = dayHeadersHeight;

            if (e.ClipRectangle.IntersectsWith(headerRectangle))
                DrawDayHeaders(e, headerRectangle);

        }
        public void Print(PaintEventArgs e)
        {
            // resolve appointments on visible date range.
            ResolveAppointmentsEventArgs args = new ResolveAppointmentsEventArgs(this.StartDate, this.StartDate.AddDays(daysToShow));
            OnResolveAppointments(args);

            using (SolidBrush backBrush = new SolidBrush(Color.White))
            //using (SolidBrush backBrush = new SolidBrush(Renderer.BackColor))
                e.Graphics.FillRectangle(backBrush, e.ClipRectangle);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Calculate visible rectangle
            Rectangle rectangle = e.ClipRectangle;

            Rectangle hourLabelRectangle = rectangle;

            hourLabelRectangle.Y += this.HeaderHeight;

            DrawHourLabels(e, hourLabelRectangle);

            Rectangle daysRectangle = rectangle;
            daysRectangle.X += hourLabelWidth;
            daysRectangle.Y += this.HeaderHeight;
            daysRectangle.Width -= hourLabelWidth;

            if (e.ClipRectangle.IntersectsWith(daysRectangle))
            {
                DrawDays(e, daysRectangle);
            }

            Rectangle headerRectangle = rectangle;

            headerRectangle.X += hourLabelWidth;
            headerRectangle.Width -= hourLabelWidth;
            headerRectangle.Height = dayHeadersHeight;

            if (e.ClipRectangle.IntersectsWith(headerRectangle))
                DrawDayHeaders(e, headerRectangle);
        }


        private void DrawHourLabels(PaintEventArgs e, Rectangle rect)
        {
            e.Graphics.SetClip(rect);

            for (int m_Hour = 0; m_Hour < 24; m_Hour++)
            {
                Rectangle hourRectangle = rect;

                hourRectangle.Y = rect.Y + (m_Hour * Cal.Part * quarterHourHeight) - scrollbar.Value;
                hourRectangle.X += hourLabelIndent;
                hourRectangle.Width = hourLabelWidth;

                if (hourRectangle.Y > this.HeaderHeight / 2)
                    renderer.DrawHourLabel(e.Graphics, hourRectangle, m_Hour);
            }

            e.Graphics.ResetClip();
        }

        private void DrawDayHeaders(PaintEventArgs e, Rectangle rect)
        {
            int dayWidth = rect.Width / daysToShow;

            // one day header rectangle
            Rectangle dayHeaderRectangle = new Rectangle(rect.Left, rect.Top, dayWidth, rect.Height);
            DateTime headerDate = startDate;

            for (int day = 0; day < daysToShow; day++)
            {
                renderer.DrawDayHeader(e.Graphics, dayHeaderRectangle, headerDate);

                dayHeaderRectangle.X += dayWidth;
                headerDate = headerDate.AddDays(1);
            }
        }

        private Rectangle GetHourRangeRectangle(DateTime start, DateTime end, Rectangle baseRectangle)
        {
            Rectangle rect = baseRectangle;

            int startY;
            int endY;

            startY = (start.Hour * quarterHourHeight * Cal.Part) + ((start.Minute * quarterHourHeight) / Cal.Minutes);
            endY = (end.Hour * quarterHourHeight * Cal.Part) + ((end.Minute * quarterHourHeight) / Cal.Minutes);

            //rect.Y = startY - scrollbar.Value + this.HeaderHeight;
            rect.Y = startY - scrollbar.Value + baseRectangle.Y;

            rect.Height = endY - startY;

            return rect;
        }

        private void DrawDay(PaintEventArgs e, Rectangle rect, DateTime time)
        {
            //renderer.DrawDayBackground(e.Graphics, rect);

            Rectangle workingHoursRectangle = GetHourRangeRectangle(workStart, workEnd, rect);

            if (workingHoursRectangle.Y < this.HeaderHeight)
                workingHoursRectangle.Y = this.HeaderHeight;

            if (!((time.DayOfWeek == DayOfWeek.Saturday) || (time.DayOfWeek == DayOfWeek.Sunday))) //weekends off -> no working hours
                renderer.DrawHourRange(e.Graphics, workingHoursRectangle, false, false);

            if ((selection == SelectionType.DateRange) && (time.Day == selectionStart.Day))
            {
                Rectangle selectionRectangle = GetHourRangeRectangle(selectionStart, selectionEnd, rect);

                renderer.DrawHourRange(e.Graphics, selectionRectangle, false, true);
            }

            e.Graphics.SetClip(rect);

            for (int hour = 0; hour < 24 * Cal.Part; hour++)
            {
                int y = rect.Top + (hour * quarterHourHeight) - scrollbar.Value;

                Pen pen;
                if (drawMarks && (hour == firstHourMark  || hour == lastHourMark ))
                    pen = new Pen(renderer.HourMarkColor);
                else if (drawMiddayMarks && (hour == startMiddayMark || hour == endMiddayMark))
                    pen = new Pen(renderer.MiddayMarkColor);
                else
                    pen = new Pen(((hour % Cal.Part) != 0 ? renderer.HourSeperatorColor : renderer.HalfHourSeperatorColor));               
                
                e.Graphics.DrawLine(pen, rect.Left, y, rect.Right, y);

                    

                if (y > rect.Bottom)
                    break;
            }

            renderer.DrawDayGripper(e.Graphics, rect, appointmentGripWidth);

            e.Graphics.ResetClip();

            /* BEGIN */
            AppointmentList appointments = (AppointmentList)cachedAppointments[time.Day];

            if (appointments != null)
            {
                List<string> groups = new List<string>();

                foreach (DVAppointment app in appointments)
                    if (!groups.Contains(app.Group))
                        groups.Add(app.Group);

                Rectangle rect2 = rect;
                rect2.Width = rect2.Width / groups.Count;

                groups.Sort();

                foreach (string group in groups)
                {
                    DrawAppointments(e, rect2, time, group);

                    rect2.X += rect2.Width;
                }
            }

            /* END */
            //for (int hour = 0; hour < 24 ; hour++)
            //{
            //    DateTime start = new DateTime(time.Year, time.Month, time.Day, hour, 0, 0);
            //    DateTime end = start.AddHours(1);
            //    AppointmentList appointments = (AppointmentList)cachedAppointments[time.Day];
            //    List<DVAppointment> drawnItems = new List<DVAppointment>();
                
            //    if (appointments != null)
            //    {
            //        List<string> groups = new List<string>();

            //        foreach (DVAppointment app in appointments)
            //        {
            //            if( app.StartDate.Hour == hour || app.EndDate.Hour == hour)
            //            if (!groups.Contains(app.Group))
            //                groups.Add(app.Group);
            //        }

            //        if (groups.Count != 0)
            //        {
            //            Rectangle rect2 = rect;
            //            rect2.Width = rect2.Width / groups.Count;

            //            groups.Sort();

            //            foreach (string group in groups)
            //            {
            //                DrawAppointments(e, rect2, start, end, group,ref drawnItems);

            //                rect2.X += rect2.Width;
            //            }
            //        }
            //    }

            //}

        }

        internal Dictionary<DVAppointment, AppointmentView> appointmentViews = new Dictionary<DVAppointment, AppointmentView>();

        private void DrawAppointments(PaintEventArgs e, Rectangle rect, DateTime startTime, DateTime endTime, string group, ref List<DVAppointment> drawnItems)
        {
            DateTime timeStart = startTime;
            DateTime timeEnd = endTime;
            timeEnd = timeEnd.AddSeconds(-1);

            AppointmentList appointments = (AppointmentList)cachedAppointments[startTime.Day];

            if (appointments != null)
            {
                HalfHourLayout[] layout = GetMaxParalelAppointments(appointments);

                for (int halfHour = 0; halfHour < 24 * Cal.Part; halfHour++)
                {
                    HalfHourLayout hourLayout = layout[halfHour];

                    if ((hourLayout != null) && (hourLayout.Count > 0))
                    {

                        for (int appIndex = 0; appIndex < hourLayout.Count; appIndex++)
                        {
                            DVAppointment appointment = hourLayout.Appointments[appIndex];

                             /* BEGIN */
                            if (appointment.Group != group)
                                continue;
                            /* END */

                            if (drawnItems.IndexOf(appointment) < 0)
                            {
                                Rectangle appRect = rect;
                                int appointmentWidth;
                                AppointmentView view;

                                appointmentWidth = rect.Width / appointment.conflictCount;

                                int lastX = 0;

                                foreach (DVAppointment app in hourLayout.Appointments)
                                {
                                    if ((app != null) && (app.Group == appointment.Group) && (appointmentViews.ContainsKey(app)))
                                    {
                                        view = appointmentViews[app];

                                        if (lastX < view.Rectangle.X)
                                            lastX = view.Rectangle.X;
                                    }
                                }

                                if ((lastX + (appointmentWidth * 2)) > (rect.X + rect.Width))
                                    lastX = 0;

                                appRect.Width = appointmentWidth - 5;

                                if (lastX > 0)
                                    appRect.X = lastX + appointmentWidth;

                                appRect = GetHourRangeRectangle(appointment.StartDate, appointment.EndDate, appRect);

                                view = new AppointmentView();
                                view.Rectangle = appRect;
                                view.Appointment = appointment;

                                appointmentViews[appointment] = view;

                                e.Graphics.SetClip(rect);

                                renderer.DrawAppointment(e.Graphics, appRect, appointment, appointment == selectedAppointment, appointmentGripWidth);

                                e.Graphics.ResetClip();

                                drawnItems.Add(appointment);
                            }
                        }
                    }
                }
            }
        }



        private void DrawAppointments(PaintEventArgs e, Rectangle rect, DateTime time, string group)
        {
            DateTime timeStart = time.Date;
            DateTime timeEnd = timeStart.AddHours(24);
            timeEnd = timeEnd.AddSeconds(-1);

            AppointmentList appointments = (AppointmentList)cachedAppointments[time.Day];

            if (appointments != null)
            {
                HalfHourLayout[] layout = GetMaxParalelAppointments(appointments);
                List<DVAppointment> drawnItems = new List<DVAppointment>();

                for (int halfHour = 0; halfHour < 24 * Cal.Part; halfHour++)
                {
                    HalfHourLayout hourLayout = layout[halfHour];

                    if ((hourLayout != null) && (hourLayout.Count > 0))
                    {
                      
                        for (int appIndex = 0; appIndex < hourLayout.Count; appIndex++)
                        {
                            DVAppointment appointment = hourLayout.Appointments[appIndex];

                            /* BEGIN */
                            if (appointment.Group != group)
                                continue;
                            /* END */
                                                        
                            if (drawnItems.IndexOf(appointment) < 0)
                            {
                                Rectangle appRect = rect;
                                int appointmentWidth;
                                AppointmentView view;

                                appointmentWidth = rect.Width / appointment.conflictCount;

                                int lastX = 0;

                                foreach (DVAppointment app in hourLayout.Appointments)
                                {
                                    if ((app != null) && (app.Group == appointment.Group) && (appointmentViews.ContainsKey(app)))
                                    {
                                        view = appointmentViews[app];

                                        if (lastX < view.Rectangle.X)
                                            lastX = view.Rectangle.X;
                                    }
                                }

                                if ((lastX + (appointmentWidth * 2)) > (rect.X + rect.Width))
                                    lastX = 0;

                                appRect.Width = appointmentWidth - 5;

                                if (lastX > 0)
                                    appRect.X = lastX + appointmentWidth;

                                appRect = GetHourRangeRectangle(appointment.StartDate, appointment.EndDate, appRect);

                                view = new AppointmentView();
                                view.Rectangle = appRect;
                                view.Appointment = appointment;

                                appointmentViews[appointment] = view;

                                e.Graphics.SetClip(rect);

                                renderer.DrawAppointment(e.Graphics, appRect, appointment, appointment == selectedAppointment, appointmentGripWidth);

                                e.Graphics.ResetClip();

                                drawnItems.Add(appointment);
                            }
                        }
                    }
                }
            }
        }

        private HalfHourLayout[] GetMaxParalelAppointments(List<DVAppointment> appointments)
        {
            HalfHourLayout[] appLayouts = new HalfHourLayout[24 * Cal.Part];

            foreach (DVAppointment appointment in appointments)
            {
                appointment.conflictCount = 1;
            }

            foreach (DVAppointment appointment in appointments)
            {
                int firstHalfHour = appointment.StartDate.Hour * Cal.Part + (appointment.StartDate.Minute / Cal.Minutes);
                int lastHalfHour = appointment.EndDate.Hour * Cal.Part + (appointment.EndDate.Minute / Cal.Minutes);

                // Added to allow small parts been displayed
                if (lastHalfHour == firstHalfHour)
                {
                    if (lastHalfHour < 24 * Cal.Part)
                        lastHalfHour++;
                    else
                        firstHalfHour--;
                }

                for (int halfHour = firstHalfHour; halfHour < lastHalfHour; halfHour++)
                {
                    HalfHourLayout layout = appLayouts[halfHour];

                    if (layout == null)
                    {
                        layout = new HalfHourLayout();
                        layout.Appointments = new DVAppointment[20];
                        appLayouts[halfHour] = layout;
                    }

                    layout.Appointments[layout.Count] = appointment;

                    layout.Count++;

                    /* BEGIN */
                    List<string> groups = new List<string>();

                    foreach (DVAppointment app2 in layout.Appointments)
                    {
                        if ((app2 != null) && (!groups.Contains(app2.Group)))
                            groups.Add(app2.Group);
                    }

                    layout.Groups = groups;

                    // update conflicts
                    foreach (DVAppointment app2 in layout.Appointments)
                    {
                        if ((app2 != null) && (app2.Group == appointment.Group))
                            if (app2.conflictCount < layout.Count)
                                app2.conflictCount = layout.Count - (layout.Groups.Count - 1);
                    }

                    /* END */
                }
            }

            return appLayouts;
        }

        private void DrawDays(PaintEventArgs e, Rectangle rect)
        {
            int dayWidth = rect.Width / daysToShow;

            AppointmentList longAppointments = (AppointmentList)cachedAppointments[-1];

            int y = dayHeadersHeight;

            if (longAppointments != null)
            {
                Rectangle backRectangle = rect;
                backRectangle.Y = y;
                backRectangle.Height = allDayEventsHeaderHeight;

                renderer.DrawAllDayBackground(e.Graphics, backRectangle);

                foreach (DVAppointment appointment in longAppointments)
                {
                    Rectangle appointmenRect = rect;

                    appointmenRect.Width = (dayWidth * (appointment.EndDate.Day - appointment.StartDate.Day));
                    appointmenRect.Height = horizontalAppointmentHeight;
                    appointmenRect.X += (appointment.StartDate.Day - startDate.Day) * dayWidth;
                    appointmenRect.Y = y;

                    renderer.DrawAppointment(e.Graphics, appointmenRect, appointment, appointment == selectedAppointment, appointmentGripWidth);

                    y += horizontalAppointmentHeight;
                }
            }

            DateTime time = startDate;
            Rectangle rectangle = rect;
            rectangle.Width = dayWidth;

            appointmentViews.Clear();

            for (int day = 0; day < daysToShow; day++)
            {
                DrawDay(e, rectangle, time);

                rectangle.X += dayWidth;

                time = time.AddDays(1);
            }
        }

        #endregion

        #region Internal Utility Classes

        class HalfHourLayout
        {
            public int Count;
            public List<string> Groups;
            public DVAppointment[] Appointments;
        }

        internal class AppointmentView
        {
            public DVAppointment Appointment;
            public Rectangle Rectangle;
        }

        class AppointmentList : List<DVAppointment>
        {
        }

        #endregion

        #region Events

        public event EventHandler SelectionChanged;
        public event ResolveAppointmentsEventHandler ResolveAppointments;
        public event NewAppointmentEventHandler NewAppointment;
        public event EventHandler<AppointmentEventArgs> AppoinmentMove;

        #endregion

        #region myOwnCents
        public void SelectAtPosition( Point p ) {
            this.SelectionStart = this.GetTimeAt(p.X, p.Y);
        }

        public void ForceClick( MouseEventArgs e ) {
            OnMouseDown( e ) ;
        }
        #endregion

    }
}
