# 🤖 .NET AI Chatbot API

ASP.NET Core ile geliştirilmiş, Groq LLM entegrasyonu içeren AI Chatbot API projesi.  
İki farklı yaklaşımla aynı proje geliştirilmiştir: **Minimal API** ve **Controller tabanlı API**.

---

## 📁 Proje Yapısı
dotnet-ai-chatbot/
├── MinimalAPI/       → app.MapPost ile endpoint tanımlama
├── ControllerAPI/    → [HttpPost] ile Controller tabanlı yapı

---

## 🛠️ Kullanılan Teknolojiler

- .NET 10
- ASP.NET Core Web API
- Groq API (LLM - llama-3.3-70b)
- OpenAI uyumlu .NET paketi

---

## 🚀 Kurulum

### 1. Repoyu klonla
```bash
git clone https://github.com/yusufcengiz00/dotnet-ai-chatbot.git
cd dotnet-ai-chatbot
```

### 2. Groq API key al
[console.groq.com](https://console.groq.com) adresinden ücretsiz hesap aç ve API key oluştur.

### 3. API key'i kaydet
```bash
cd ControllerAPI
dotnet user-secrets init
dotnet user-secrets set "GroqApiKey" "senin_key_in"
```

### 4. Çalıştır
```bash
dotnet run
```

---

## 📡 Endpoint'ler

### GET /api/restAPIControllers/merhaba
```json
{ "mesaj": "Merhaba Gama Mühendislik!" }
```

### POST /api/restAPIControllers
```json
// İstek:
{ "mesaj": "Merhaba, sen kimsin?" }

// Cevap:
{ "cevap": "Ben bir yapay zeka asistanıyım..." }
```
