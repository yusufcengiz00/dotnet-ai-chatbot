# 🤖 .NET AI Chatbot API

![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=for-the-badge&logo=dotnet)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-18-316192?style=for-the-badge&logo=postgresql)
![Groq](https://img.shields.io/badge/Groq-Llama_3.3-F54E00?style=for-the-badge)
![Lisans](https://img.shields.io/badge/lisans-MIT-green?style=for-the-badge)

ASP.NET Core 10 ile geliştirilmiş, Groq LLM entegrasyonu, Dapper ile PostgreSQL mesaj kaydı ve iki farklı mimari yaklaşım içeren AI Chatbot API projesi.

---

## 🏗️ Mimari Kararlar

Bu proje, aynı problemi iki farklı yaklaşımla çözerek mimari farkları ortaya koymak amacıyla tasarlanmıştır.

| | Minimal API | Controller API |
|---|---|---|
| **Yapı** | `app.MapPost()` | `[HttpPost]` attribute |
| **Kullanım** | Küçük/microservice projeler | Kurumsal, büyük ekipler |
| **Esneklik** | Yüksek | Orta |
| **Okunabilirlik** | Büyüdükçe zorlaşır | Her zaman düzenli |

---

## 🛠️ Kullanılan Teknolojiler

- **Runtime:** .NET 10 / ASP.NET Core
- **Yapay Zeka:** Groq API — Llama 3.3 70B (OpenAI uyumlu)
- **Veritabanı:** PostgreSQL 18 + Dapper (hafif ORM)
- **Güvenlik:** .NET User Secrets (API key yönetimi)

---

## ✨ Özellikler

- 🧠 Groq API üzerinden gerçek zamanlı LLM cevapları
- 💾 Mesajların PostgreSQL'e asenkron kaydedilmesi
- 📜 Mesaj geçmişi listeleme
- 🔐 User Secrets ile güvenli API key yönetimi
- 🏗️ İki farklı API mimarisi: Minimal API ve Controller tabanlı

---

## 🚀 Kurulum

### Gereksinimler
- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [PostgreSQL 18](https://www.postgresql.org/download)
- [Groq API Key](https://console.groq.com) (ücretsiz)

### 1. Repoyu klonla
```bash
git clone https://github.com/yusufcengiz00/dotnet-ai-chatbot.git
cd dotnet-ai-chatbot
```

### 2. Veritabanı tablosunu oluştur
```sql
CREATE TABLE chat_history (
    id SERIAL PRIMARY KEY,
    user_message TEXT NOT NULL,
    bot_response TEXT NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
```

### 3. API key ve bağlantı bilgilerini kaydet
```bash
cd ControllerAPI
dotnet user-secrets init
dotnet user-secrets set "GroqApiKey" "groq_api_key_in"
dotnet user-secrets set "ConnectionStrings:PostgreSQL" "Host=localhost;Port=5432;Database=chatbot;Username=postgres;Password=sifren"
```

### 4. Çalıştır
```bash
dotnet run
```

---

## 📡 API Endpoint'leri

### `POST /api/restAPIControllers`
```json
// İstek:
{ "mesaj": "Merhaba, sen kimsin?" }

// Cevap:
{ "cevap": "Ben bir yapay zeka asistanıyım..." }
```

### `GET /api/restAPIControllers/history`
Tüm mesaj geçmişini listeler.
```json
[
  {
    "id": 1,
    "user_message": "Merhaba!",
    "bot_response": "Merhaba, nasıl yardımcı olabilirim?",
    "created_at": "2026-04-06T12:00:00"
  }
]
```

---

## 📸 Demo

<img width="1376" height="425" alt="postman-demo" src="https://github.com/user-attachments/assets/82eef07a-7b8a-4cf3-ad55-0716598ae71e" />

---

## 📄 Lisans

MIT
