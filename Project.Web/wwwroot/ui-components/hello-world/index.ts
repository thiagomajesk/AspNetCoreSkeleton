import { ko, Component, ViewModelClass, ViewModel } from "knockout.bootstrapper";
import template from './index.html';
import './index.scss';

export class HelloWorldComponent extends Component {
    constructor(name?: string, viewModel?: ViewModelClass) {
        super(name, viewModel, template)
    }
}

export class HelloWorldViewModel extends ViewModel {

    public isHidden: ko.Observable<boolean> = ko.observable<boolean>(true);

    public buttonText: ko.Computed<string>;

    public constructor(params?: any) {
        super(params)

        this.buttonText = ko.computed<string>(() =>
            this.isHidden() ? "Show Hello" : "Hide Hello");
    }

    public toggleHello(): void {
        this.isHidden(!this.isHidden());
    }
}