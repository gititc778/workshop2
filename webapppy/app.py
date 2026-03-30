from flask import Flask, render_template, request, redirect

app = Flask(__name__)

tires = []

@app.route("/")
def index():
    return render_template("index.html", tires=tires)

@app.route("/add", methods=["GET", "POST"])
def add():
    if request.method == "POST":
        tires.append({
            "brand": request.form["brand"],
            "size": request.form["size"],
            "price": request.form["price"]
        })
        return redirect("/")
    return render_template("add.html")

if __name__ == "__main__":
    app.run(host="0.0.0.0", port=5000, debug=True)
