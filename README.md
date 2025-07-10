# English Exam - Hệ thống thi trắc nghiệm tiếng Anh

## 📋 Mô tả dự án

English Exam là một ứng dụng desktop WPF được xây dựng bằng C# và .NET 8, chuyên về tạo và quản lý các bài thi trắc nghiệm tiếng Anh. Hệ thống hỗ trợ tạo đề thi tự động và thủ công, theo dõi kết quả thi, và quản lý ngân hàng câu hỏi.

### 🎯 Tính năng chính
- **Quản lý câu hỏi**: CRUD câu hỏi trắc nghiệm với 4 đáp án
- **Tạo đề thi**: Tự động (random) và thủ công
- **Làm bài thi**: Giao diện thi trắc nghiệm thân thiện
- **Chấm điểm**: Tự động tính điểm và hiển thị kết quả
- **Quản lý user**: Đăng ký, đăng nhập, phân quyền
- **Thống kê**: Xem lịch sử thi và điểm số
- **Ngân hàng câu hỏi**: Quản lý câu hỏi theo chủ đề

## 🛠️ Công nghệ sử dụng

### Backend & Database
- **.NET 8 WPF**
- **Entity Framework Core 8**
- **Microsoft SQL Server**
- **LINQ**

### Frontend
- **WPF (Windows Presentation Foundation)**
- **XAML**
- **C#**

### Database
- **Microsoft SQL Server**
- **Entity Framework Migrations**

## 📦 Cài đặt và chạy dự án

### Yêu cầu hệ thống
- **Windows 10/11**
- **.NET 8 SDK**
- **SQL Server 2019+**
- **Visual Studio 2022** hoặc **VS Code**

### Bước 1: Clone repository
```bash
git clone <repository-url>
cd English-Exam
```

### Bước 2: Cấu hình Database
1. Mở SQL Server Management Studio
2. Tạo database mới tên `ProjectPRN`
3. Chạy script SQL từ file `project.sql`
4. Cập nhật connection string trong `appsettings.json`:
   ```json
   "ConnectionStrings": {
       "MyCnn": "server=YOUR_SERVER;database=ProjectPRN;uid=sa;pwd=123;TrustServerCertificate=True;"
   }
   ```

### Bước 3: Chạy ứng dụng
1. Mở solution `ProjectPRN.sln` trong Visual Studio
2. Restore NuGet packages
3. Build solution
4. Chạy ứng dụng (F5)

## 👥 Hệ thống vai trò

### 🔐 Admin (role = 1)
- Quản lý toàn bộ hệ thống
- Tạo và quản lý câu hỏi
- Tạo đề thi (tự động/thủ công)
- Xem thống kê và báo cáo
- Quản lý tài khoản người dùng

### 👤 User (role = 0)
- Đăng ký/đăng nhập tài khoản
- Xem danh sách đề thi
- Làm bài thi
- Xem kết quả và lịch sử thi
- Quản lý thông tin cá nhân

## 📁 Cấu trúc dự án

```
English-Exam/
├── ProjectPRN/              # Main WPF Application
│   ├── Models/              # Entity models
│   │   ├── Account.cs       # User model
│   │   ├── Question.cs      # Question model
│   │   ├── Exam.cs          # Exam model
│   │   ├── Score.cs         # Score model
│   │   └── ProjectPrnContext.cs # DbContext
│   ├── *.xaml               # WPF Windows
│   ├── *.xaml.cs            # Code-behind files
│   ├── appsettings.json     # Configuration
│   └── ProjectPRN.csproj    # Project file
├── project.sql              # Database script
└── ProjectPRN.sln           # Solution file
```

## 🗄️ Database Schema

### Bảng chính
- **Account**: Thông tin tài khoản người dùng
- **Question**: Câu hỏi trắc nghiệm với 4 đáp án
- **Exam**: Thông tin đề thi
- **ExamQuestions**: Bảng trung gian (Exam-Question)
- **Score**: Điểm số và kết quả thi
- **UserAnswers**: Câu trả lời của người dùng

### Dữ liệu mẫu
- **3 tài khoản**: 1 admin, 2 user
- **50+ câu hỏi** tiếng Anh đa dạng
- **Các loại câu hỏi**:
  - Chọn từ đồng nghĩa
  - Chọn từ trái nghĩa
  - Tìm câu nghĩa tương đương
  - Tìm lỗi sai trong câu
  - Chọn từ thích hợp điền vào chỗ trống

## 🚀 Tính năng nổi bật

### 📝 Quản lý câu hỏi
- **CRUD Operations**: Thêm, sửa, xóa, xem câu hỏi
- **Multiple Choice**: 4 đáp án cho mỗi câu hỏi
- **Question Types**: 5 loại câu hỏi khác nhau
- **Content Management**: Quản lý nội dung câu hỏi

### 🎯 Tạo đề thi
- **Random Exam**: Tạo đề thi tự động với số câu hỏi tùy chọn
- **Manual Exam**: Chọn câu hỏi thủ công
- **Time Calculation**: Tự động tính thời gian làm bài
- **Duplicate Prevention**: Ngăn chặn trùng tên đề thi

### 📊 Hệ thống thi
- **User Interface**: Giao diện thi thân thiện
- **Timer**: Đếm ngược thời gian làm bài
- **Auto Submit**: Tự động nộp bài khi hết giờ
- **Progress Tracking**: Theo dõi tiến độ làm bài

### 📈 Chấm điểm và kết quả
- **Auto Grading**: Tự động chấm điểm
- **Score Calculation**: Tính điểm chính xác
- **Result Display**: Hiển thị kết quả chi tiết
- **History Tracking**: Lưu lịch sử thi

### 🔐 Authentication & Authorization
- **User Registration**: Đăng ký tài khoản
- **User Login**: Đăng nhập hệ thống
- **Role-based Access**: Phân quyền Admin/User
- **Session Management**: Quản lý phiên đăng nhập

## 🎨 Giao diện người dùng

### Windows chính
- **MainWindow**: Cửa sổ chính với menu navigation
- **FrmRegister**: Đăng ký tài khoản mới
- **FrmUser**: Giao diện người dùng
- **FrmAdmin**: Giao diện quản trị
- **FrmExam**: Quản lý đề thi
- **FrmDoExam**: Làm bài thi
- **FrmExamResults**: Xem kết quả thi

### UI Features
- **Modern Design**: Giao diện hiện đại với WPF
- **Responsive Layout**: Tương thích nhiều độ phân giải
- **User-friendly**: Dễ sử dụng và trực quan
- **Data Binding**: Binding dữ liệu real-time

## 🔒 Security Features

### Authentication
- **Password Protection**: Bảo vệ mật khẩu
- **User Validation**: Xác thực người dùng
- **Session Control**: Kiểm soát phiên làm việc

### Data Protection
- **Input Validation**: Validate dữ liệu đầu vào
- **SQL Injection Prevention**: EF Core protection
- **Data Integrity**: Đảm bảo tính toàn vẹn dữ liệu

## 📊 Tính năng quản lý

### Admin Dashboard
- **Question Management**: Quản lý câu hỏi
- **Exam Creation**: Tạo đề thi
- **User Management**: Quản lý người dùng
- **Statistics**: Thống kê và báo cáo

### User Dashboard
- **Exam List**: Danh sách đề thi
- **Take Exam**: Làm bài thi
- **View Results**: Xem kết quả
- **Profile Management**: Quản lý thông tin

## 🧪 Testing & Quality

### Data Validation
- **Input Validation**: Kiểm tra dữ liệu đầu vào
- **Business Logic**: Logic nghiệp vụ chặt chẽ
- **Error Handling**: Xử lý lỗi thân thiện

### Performance
- **Efficient Queries**: Truy vấn database tối ưu
- **Memory Management**: Quản lý bộ nhớ hiệu quả
- **UI Responsiveness**: Giao diện mượt mà

## 📝 License

Dự án được phát triển cho mục đích học tập và nghiên cứu.

## 🤝 Đóng góp

1. Fork dự án
2. Tạo feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to branch (`git push origin feature/AmazingFeature`)
5. Tạo Pull Request

## 📞 Liên hệ

- **Email**: admin1@gmail.com
- **Project Link**: [https://github.com/your-username/English-Exam](https://github.com/your-username/English-Exam)

---

⭐ Nếu dự án này hữu ích, hãy cho chúng tôi một star! 