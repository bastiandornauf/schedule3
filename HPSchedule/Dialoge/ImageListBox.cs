using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Text;

namespace ImageListBox
{
    /// <summary>
    /// ImageListBox malt schöne Bildchen
    /// wenn man als Items voll referenzierte Pfade zu Bildern liefert,
    /// welche mit ImageFromFile geladen werden können.
    ///
    /// Exceptions werden direkt in der ListBox angezeigt !!
    ///
    /// Erstellt durch: Programmierhans
    /// Art:            Freeware
    /// Zeitaufwand:    20 Minuten (wobei die Thumb-Methode schon existiert hat)
    /// </summary>
    public class ImageListBox : ListBox
    {
        public ImageListBox()
            : base()
        {
            this.DrawMode = DrawMode.OwnerDrawFixed;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            base.OnDrawItem(e);
            if (e.Index > -1 && this.Items.Count > e.Index)
            {
                object itm = this.Items[e.Index];
                if (itm != null)
                {
                    string fileName = itm.ToString();
                    if (System.IO.File.Exists(fileName))
                    {
                        Image img = null;
                        try
                        {
                            img = Image.FromFile(fileName);
                            if (img != null)
                            {
                                Graphics g = e.Graphics;
                                Image img2 = this.GetThumbnail(img, e.Bounds);
                                g.DrawImageUnscaled(img2, e.Bounds);
                            }
                        }
                        catch (Exception ex)
                        {
                            Graphics g = e.Graphics;
                            StringFormat sf = new StringFormat();
                            sf.Trimming = StringTrimming.EllipsisCharacter;
                            string message = string.Format("{0} konnte nicht geladen werden. Exception: {1}", fileName, ex.ToString());
                            g.DrawString(message, this.Font, new SolidBrush(this.ForeColor), e.Bounds, sf);
                        }
                    }
                }
            }
        }

        private Image GetThumbnail(Image pImage, Rectangle pBounds)
        {
            Image ret = new Bitmap(pBounds.Width, pBounds.Height);
            Graphics g = Graphics.FromImage(ret);
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, ret.Width, ret.Height);

            float factor = Math.Max((float)pImage.Width / (float)pBounds.Width, (float)pImage.Height / (float)pBounds.Height);
            g.DrawImage(pImage, 0, 0, (float)pImage.Width / factor, (float)pImage.Height / factor);
            g.Dispose();

            return ret;
        }

    }
}
