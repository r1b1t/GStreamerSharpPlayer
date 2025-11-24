# 🎬 GStreamerSharpPlayer

C# WinForms ile geliştirilmiş basit ama genişletilebilir bir **GStreamer medya oynatıcı**.

Bu proje, kullanıcıların kendi GStreamer pipeline’larını **elle girip**,  
Play/Stop kontrolü üzerinden çalıştırmasını ve video çıktısını WinForms paneline **render etmesini** sağlar.

Tamamen eğitim, prototip geliştirme, RTSP/UDP/WebRTC testleri ve GStreamer öğrenimi için tasarlanmış minimalist bir örnek uygulamadır.

---

## ✨ Özellikler

- ✔️ C# (.NET Framework) üzerinde GStreamer kullanımı  
- ✔️ Kullanıcı tarafından girilen pipeline string’ini çalıştırma  
- ✔️ Video çıkışının WinForms paneline yönlendirilmesi  
- ✔️ Play / Stop kontrol butonları  
- ✔️ GStreamer’ın **VideoOverlay API** ile pencere içine video çizme  
- ✔️ Eski pipeline’ın düzgün şekilde Dispose edilmesi  
- ✔️ Basit, anlaşılır mimari  
- ✔️ GStreamer’ı C# tarafında öğrenmek için ideal örnek proje  

---

## 🛠️ Kullanılan Teknolojiler

- **C# – WinForms (.NET Framework)**
- **GStreamer (GstSharp binding)**
- **VideoOverlayAdapter**
- **Visual Studio 2022**

---

## 📦 Kurulum

### 1️⃣ GStreamer Kurulumu  
GStreamer’ın *Complete* sürümünü indirip kurun:

👉 https://gstreamer.freedesktop.org/download/

PATH değişkenine şu klasör ekli olmalı:

```
C:\gstreamer\1.0\msvc_x86_64\bin
```

---

### 2️⃣ NuGet Üzerinden GstSharp Kurulumu

```
Tools → NuGet Package Manager → Manage NuGet Packages
```

`GstSharp` paketini yükleyin.

---

## ▶️ Çalıştırma

Pipeline’ı textbox’a yazın, örneğin:

```
videotestsrc ! videoconvert ! d3dvideosink
```

**Play** butonuna basın.  
Video siyah panel üzerinde oynar.

**Stop** ile pipeline sonlandırılır.

---

## 📘 Örnek Pipeline'lar

### ✔️ Test pattern
```
videotestsrc ! videoconvert ! d3dvideosink
```

### ✔️ Kamera yayını
```
ksvideosrc ! videoconvert ! d3dvideosink
```

---

## 🧩 Projenin Amacı

Bu proje, GStreamer'ı .NET ortamında nasıl entegre edeceğimi öğrenmek  
ve ileride oluşturacağım medya uygulamalarına temel oluşturmak için yazıldı.

Amaçlar:

- GStreamer pipeline mantığını WinForms üzerinden kontrol etmek  
- VideoOverlay API'sini C# tarafında doğru şekilde kullanmak  

---

## 🚀 Sonuç

**GStreamerSharpPlayer**, GStreamer + C# entegrasyonunu öğrenmek isteyen herkes için  
basit, anlaşılır ve genişletilebilir bir örnek projedir.

RTSP / UDP / WebRTC gibi medya projelerinde başlangıç noktası olarak rahatlıkla kullanılabilir.

