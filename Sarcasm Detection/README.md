# **UIT Data Science Challenge 2024**  
### **Multimodal Sarcasm Detection**  

This project is part of the **UIT Data Science Challenge 2024**,  
focusing on sarcasm detection in **multimodal data** (text and images).  

---  

## **Approach**  

### 📌 **1. Text Extraction from Images**  
- Utilized an **OCR model** combined with **image cropping techniques**  
  to enhance text extraction accuracy from images.  

### 📌 **2. Multimodal Embedding with CLIP**  
- Employed the **CLIP model** to generate embeddings for both text and images,  
  ensuring a **unified representation** of multimodal data.  

### 📌 **3. Multi-Modal Sarcasm Detection Model**  
- Developed a **CNN model with Self-Attention** to process:  
  - Image embeddings  
  - Text embeddings  
  - Combined image-text embeddings  
- Applied **Over-Sampling** and **Weighted Loss** to handle class imbalance.  
- Implemented **K-Fold Cross-Validation** to improve model generalization.  
- Used a **custom F1-Macro callback** to track performance  
  and save the best model for each fold.  

### 📌 **4. Evaluation**  
- Model performance is evaluated using the **F1-macro score**  
  due to **severe class imbalance**.  
- This ensures a **fair assessment** across all labels,  
  preventing the model from **favoring majority classes**.  

🏆 **Our model consistently ranked 1st place among all teams**  
for over half of the competition’s first month,  
demonstrating its effectiveness in sarcasm detection.  

---  

## **About Me**  

🚀 I am passionate about advancing my expertise in **Data Science & AI**  
and applying it to **real-world projects** that address critical business challenges.  

🔥 I believe the **Viettel Digital Talent** program will be the perfect launchpad  
to help me achieve this goal.  

💡 With a strong commitment to **continuous learning and innovation**,  
I am eager to contribute my skills in **Computer Vision, NLP, and Machine Learning**  
to **impactful AI-driven solutions**.  

🤝 I am excited about the opportunity to **collaborate with top experts**,  
engage in **cutting-edge research**, and develop technologies  
that **optimize business operations** and **enhance user experiences**.  

📩 I look forward to discussing my **passion, career aspirations**,  
and how I can contribute to this **dynamic program**.
