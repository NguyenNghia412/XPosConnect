chrome.runtime.onMessage.addListener((request, sender, sendResponse) => {
  const BASE_URL = "http://localhost:6002/api/communicate";
  let url = "";
  if (request.type === "show-qr") {
    url = `${BASE_URL}/show-qr`;
  }

  if (request.type === "show-text") {
    url = `${BASE_URL}/show-text`;
  }
  
  console.log("BACKGROUND CALL SERVICE");

  // Example: direct call to localhost:6002
  fetch(url, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(request.payload),
  })
    .then((res) => {
      console.log("BACKGROUND SHOW RESPONSE", res);
      res.json();
    })
    .then((data) => {
      console.log("BACKGROUND SHOW RESPONSE JSON", data);
      sendResponse(data);
    })
    .catch((err) => {
      console.error("BACKGROUND SHOW ERROR", err);
      sendResponse(err);
    });

  return true; // keep channel open for async response
});
