//اختيار المركز
  const cities = {
    "Cairo": ["المعادي", "الزمالك", "مدينة نصر", "مصر الجديده"],
    "Alexandria": ["المنتزه", "برج العرب", "المعمورة"],
    "Giza": ["الشيخ زايد", "6اكتوبر", "الهرم", "الدقي"],
    "Luxor": ["الكرنك", "الضفة الغربية"],
};

// Function to update the second dropdown based on the selected governorate
function updateCities() {
    const fromSelect = document.getElementById("from");
    const toSelect = document.getElementById("to");
    const selectedGovernorate = fromSelect.value;

    // Clear previous options in the 'to' dropdown
    toSelect.innerHTML = '<option value="">اختر المدينة</option>';

    // If a governorate is selected, add the cities to the 'to' dropdown
    if (selectedGovernorate && cities[selectedGovernorate]) {
        cities[selectedGovernorate].forEach(city => {
            const option = document.createElement("option");
            option.value = city;
            option.textContent = city;
            toSelect.appendChild(option);
        });
    }
}

// Add event listener to the first dropdown to call the function when the value changes
document.getElementById("from").addEventListener("change", updateCities);
//النجوم تظهر في الكارد
// استرجاع التقييمات المخزنة في localStorage وتحديث النجوم بناءً عليها
for (let i = 1; i <= 6; i++) {
    const ratingCard = localStorage.getItem(`ratingCard${i}`); // استرجاع التقييم من localStorage بناءً على ID الكرت

    if (ratingCard) {
        const starRatingElement = document.getElementById(`star-rating-${i}`); // الحصول على عنصر النجوم بناءً على ID الكرت
        let stars = '';
        for (let j = 0; j < ratingCard; j++) {
            stars += '⭐';  // إضافة النجوم الذهبية
        }
        // عرض النجوم في العنصر
        starRatingElement.textContent = stars;
    }
}


////
// إضافة حدث عند النقر على أي زر من الأزرار
document.querySelectorAll('.icon-box').forEach(link => {
    link.addEventListener('click', function(event) {
      // منع السلوك الافتراضي للرابط (الانتقال إلى صفحة أخرى)
      event.preventDefault();
      
      // يمكنك هنا إضافة أي عمليات تريد تنفيذها قبل الانتقال إلى الصفحة
      console.log('تم النقر على زر: ' + link.textContent);
      
      // الانتقال إلى الصفحة المحددة في سمة href
      window.location.href = link.href;
    });
  });
  // Function to navigate to the map page
  function openMap() {
      window.location.href = 'map.html'; // URL for the map page
  }
   // Function to navigate to the map page
   function openMap() {
    window.location.href = 'map.html'; // URL for the map page
}