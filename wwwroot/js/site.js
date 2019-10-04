getPartial = async function(url, div = "partialScreen", self = null) {
  try {
    if (div != "partialScreen") {
      const tagsButton = document.getElementsByName("tagsButton");
      for (const t of tagsButton) {
        if (t.id === self.id) {
          t.classList.remove("is-outlined");
        } else {
          t.classList.add("is-outlined");
        }
      }
    }
    const response = await fetch(encodeURI(url));
    const html = await response.text();
    document.getElementById(div).innerHTML = html;
  } catch (error) {
    document.getElementById(div).innerHTML = error;
  }
};

const buttons = document.getElementsByName("menu");
for (const button of buttons) {
  button.addEventListener("click", function() {
    for (const b of buttons) {
      if (b.id === this.id) {
        b.classList.remove("is-outlined");
      } else {
        b.classList.add("is-outlined");
      }
    }
  });
}

function postMail() {
  const myForm = document.getElementById("mailler");
  const formData = new FormData(myForm);
  fetch("/Index?handler=ContactPartial", {
    method: "post",
    body: new URLSearchParams(formData)
  }).then(res => {
    res.text().then(text => {
      document.getElementById("partialScreen").innerHTML = text;
    });
  });
  return false;
}
