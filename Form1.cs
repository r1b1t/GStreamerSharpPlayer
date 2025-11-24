using System;
using System.Windows.Forms;
using Gst;
// Gst.Video → VideoOverlayAdapter gibi video işleme sınıfları
using Gst.Video;

namespace gstreamerplayer
{
	public partial class Form1 : Form
	{
		Pipeline pipeline;

		public Form1()
		{
			// GStreamer başlat
			Gst.Application.Init();
			// Form tasarımını WinForms oluşturur.
			InitializeComponent();
		}

		// Pipeline temizleme metodu
		private void Cleanup()
		{
			if (pipeline != null)
			{
				pipeline.SetState(State.Null);

				// Bus temizliği
				var bus = pipeline.Bus;
				bus?.Dispose(); // Dispose ile bus nesnesini serbest bırak

				// Pipeline unref
				pipeline.Dispose();
				pipeline = null;

				panel1.CreateGraphics().Clear(panel1.BackColor);
				panel1.Refresh();
			}
		}


		// Pipeline başlatma butonu
		private void button1_Click(object sender, EventArgs e)
		{
			string pipelineStr = textBox1.Text;

			if (string.IsNullOrWhiteSpace(pipelineStr))
			{
				MessageBox.Show("Pipeline boş olamaz!");
				return;
			}

			// Eski pipeline'ı kapat
			if (pipeline != null)
			{
				pipeline.SetState(State.Null); // Pipeline'ı null yap, sıfırla
				pipeline.Dispose(); // Kaynakları serbest bırak, hafıza serbest bırakılır
				pipeline = null; // Bellek sızıntısını önle
			}

			try
			{
				// Yeni pipeline oluştur
				pipeline = Parse.Launch(pipelineStr) as Pipeline; // Parse.Launch ile pipeline oluştur

				// Video çıktısını panel'e yönlendirme
				Element videoSink = pipeline.GetByInterface(VideoOverlayAdapter.GType); // VideoOverlayAdapter : GStreamer’ın “video bu pencereye çiz” arayüzü ; GetByInterface Bu pipeline’ın içindeki, VideoOverlay destekleyen elemanı (sink’i) bul” demek

				if (videoSink != null)
				{
					/* videoSink.Handle → GStreamer içindeki o sink elementinin native pointer’ı (C tarafındaki adresi).
                    VideoOverlayAdapter → Bu pointer’ı kullanarak VideoOverlay API’sine ulaşan C# tarafındaki “köprü” sınıfı.*/
					VideoOverlayAdapter overlay = new VideoOverlayAdapter(videoSink.Handle); 
					overlay.WindowHandle = panel1.Handle; // panel1'in pencere tanıtıcısını (handle) ata

				}
				else
				{
					MessageBox.Show("Video çıkışı bulunamadı! Sink d3dvideosink olmalı.");
				}

				// Çalıştır
				pipeline.SetState(State.Playing);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Pipeline hatası:\n" + ex.Message);
			}
		}

		// Pipeline durdurma butonu
		private void button2_Click(object sender, EventArgs e)
		{
			if (pipeline == null)
			{
				MessageBox.Show("Pipeline başlatılmamış!");
				return;
			}

			try
			{
				Cleanup();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Pipeline kapatılırken hata oluştu:\n" + ex.Message);
			}

		}

		// Form kapanırken pipeline'ı temizle
		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			Cleanup();
			base.OnFormClosing(e);
		}

	}
}
