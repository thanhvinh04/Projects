# 📝 **ECOMMERCE FEEDBACK ANALYSIS**

## 📌 **Tổng quan dự án**

Dự án này nhằm phân tích phản hồi của khách hàng trên nền tảng thương mại điện tử **Shopee** để hiểu rõ các vấn đề mà khách hàng đang gặp phải, từ đó hỗ trợ doanh nghiệp:
- Nâng cao trải nghiệm người dùng
- Cải thiện hoạt động kinh doanh
- Tăng tỷ lệ giữ chân khách hàng và tối ưu hóa doanh thu

Thông qua việc ứng dụng **Machine Learning** và công cụ **Business Intelligence (BI)**, dự án giúp doanh nghiệp theo dõi và phân tích phản hồi theo thời gian, phát hiện xu hướng cảm xúc của người dùng, và xác định nhóm khách hàng cần được quan tâm.

---

## 🧠 **Mục tiêu dự án**

- 🔍 Trích xuất và làm sạch dữ liệu phản hồi từ API Shopee
- 🧠 Áp dụng **Topic Modeling** để phân loại chủ đề khách hàng phản ánh
- 😊 Thực hiện **Sentiment Analysis** để xác định mức độ hài lòng theo từng chủ đề
- 🧩 Phân cụm khách hàng dựa trên hành vi và cảm xúc trong phản hồi
- 📊 Trực quan hóa dữ liệu bằng **Power BI** giúp doanh nghiệp dễ dàng theo dõi insight và đưa ra quyết định kịp thời

---

## 🗂️ **Nguồn dữ liệu**

- Thu thập từ API của Shopee: bao gồm các trường như **thời gian**, **nội dung phản hồi**, **tên sản phẩm**, **danh mục**, v.v.
- Dữ liệu được xử lý thêm bằng NLP để tạo thành các trường:
  - **Chủ đề phản hồi (Topic)**
  - **Tính cảm xúc (Positive / Negative / Neutral)**
  - **Từ khóa nổi bật** mà khách hàng đề cập
  - **Nhóm khách hàng theo hành vi**

---

## 🔧 **Công cụ & Kỹ thuật sử dụng**

| 🧰 Công cụ | 📌 Mục đích sử dụng |
|-----------|----------------------|
| **Python** (NLTK, sklearn, gensim) | Tiền xử lý dữ liệu, topic modeling, sentiment analysis |
| **Excel / Google Sheets** | Đối chiếu và xử lý nhanh dữ liệu đầu vào |
| **Power BI** | Xây dựng dashboard tương tác, trực quan hóa insight cho doanh nghiệp |

---

## 📊 **Kết quả đạt được**

- ✅ **Phân tích chủ đề (Topic Modeling)** cho thấy 5 chủ đề phản hồi phổ biến: chất lượng sản phẩm, giao hàng, đóng gói, chăm sóc khách hàng và giá cả.
- ✅ **Phân tích cảm xúc** giúp xác định tỷ lệ phản hồi tiêu cực cao nhất nằm ở chủ đề "giao hàng trễ", trong khi chủ đề "giá cả" nhận nhiều phản hồi tích cực.
- ✅ **Phân cụm khách hàng** giúp xác định nhóm:
  - Người dùng thường xuyên phản ánh tiêu cực
  - Người dùng trung lập dễ bị mất nếu không có cải thiện
  - Người dùng hài lòng cao, có khả năng trung thành
- ✅ **Dashboard Power BI** cung cấp góc nhìn toàn diện:
  - Xu hướng cảm xúc theo thời gian
  - So sánh phản hồi theo ngành hàng / sản phẩm
  - Mức độ hài lòng theo nhóm khách hàng
- ✅ Đưa ra các khuyến nghị thực tế: cải thiện tốc độ giao hàng, thiết kế chương trình ưu đãi cho khách hàng tiêu cực – trung lập để cải thiện hình ảnh thương hiệu.
- 
