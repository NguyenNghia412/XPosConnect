chrome.runtime.onMessage.addListener((request, sender, sendResponse) => {
  if (request.type === "show-qr") {
    console.log('BACKGROUND SHOW QR')
    // Example: direct call to localhost:6002
    fetch("http://localhost:6002/api/communicate/show-qr", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify(request.payload)
    })
    .then(res => {
        console.log('BACKGROUND RESPONSE', res)
        res.json()
      })
      .then(data => sendResponse(data))
      .catch(err => sendResponse(err));

    return true; // keep channel open for async response
  }
});
