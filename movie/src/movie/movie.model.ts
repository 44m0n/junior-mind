class MovieModule {
    private _id: number;
    private _title: string;
    private _date: Date;
    private _genre: string;
    private _price: number;


    get Id() {
        return this._id;
    }

    set Id(value) {
        this._id = value;
    }

    get Title() {
        return this._title;
    }

    set Title(value) {
        this._title = value;
    }

    get ReleaseDate() {
        return this._date;
    }

    set ReleaseDate(value) {
        this._date = value;
    }

    get Genre() {
        return this._genre;
    }

    set Genre(value) {
        this._genre = value;
    }

    get Price() {
        return this._price;
    }

    set Price(value) {
        this._price = value;
    }
}