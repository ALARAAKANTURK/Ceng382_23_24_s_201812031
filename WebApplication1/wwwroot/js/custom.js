document.addEventListener('DOMContentLoaded', function() {
    // Toggle elements
    const toggleBtn = document.getElementById('toggleButton');
    const elementsToToggle = document.getElementById('elementsToToggle');
    toggleBtn.addEventListener('click', function() {
      if (elementsToToggle.style.display === 'none') { //tipe bakmaksızın
        elementsToToggle.style.display = 'block';
        toggleBtn.textContent = 'Hide';
      } else {
        elementsToToggle.style.display = 'none'; //tipe bakar
        toggleBtn.textContent = 'Show';
      }
    });
  
    // Calculate sum
    const calculateSumBtn = document.getElementById('calculateSumBtn');
    const sumForm = document.getElementById('sumForm');
    const calculateBtn = document.getElementById('calculateBtn');
    const sumResult = document.getElementById('sumResult');
    document.getElementById('sumResult').style.display='block';
    calculateSumBtn.addEventListener('click', function() {
      sumForm.style.display = 'block';
    });
  
    calculateBtn.addEventListener('click', function() {
      const input1 = parseFloat(document.getElementById('input1').value);
      const input2 = parseFloat(document.getElementById('input2').value);
  
      if (!isNaN(input1) && !isNaN(input2)) {
        const sum = input1 + input2;
        sumResult.textContent = `Sum: ${sum}`;
      
      } else {
        sumResult.textContent = 'Please enter valid numbers.';
      }
    });
  });
  