function ShowBuyPrice() {
    
    document.getElementById('RentPrice').className = 'text-hide';
    document.getElementById('BuyPrice').className = 'show';
}

function ShowRentPrice() {
    
    document.getElementById('BuyPrice').className = 'text-hide';
    document.getElementById('RentPrice').className = 'show';
}