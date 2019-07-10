import { ko, ViewModel } from "knockout.bootstrapper";

export class AdminHomeIndexViewModel extends ViewModel {

    public count: ko.Observable<number> = ko.observable<number>(0);

    public message: ko.Computed<string|null>;

    constructor(params?: any) {
        super(params);

        this.message = ko.computed<string|null>(() => {
            if (this.count() >= 10 && this.count() <= 20) return "You should give up";
            if (this.count() >= 20 && this.count() <= 30) return "Stop clicking!";
            if (this.count() == 30 && this.count() <= 50) return "Are you still clicking?";
            if (this.count() == 50 && this.count() <= 100) return "There's no more messages";
            if (this.count() >= 100 && this.count() <= 110) return "Ok, just this one left";
            return null;
        });

    }

    public click(): void {
        this.count(this.count() + 1);
    }
}