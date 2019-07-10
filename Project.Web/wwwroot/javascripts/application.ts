import { Application } from "knockout.bootstrapper";
import { HelloWorldComponent, HelloWorldViewModel } from "../ui-components/hello-world";
import { AdminHomeIndexViewModel } from "./areas/admin/home.index";

const application = new Application();

application.registerViewModel("admin-home", AdminHomeIndexViewModel);

application.registerComponent("hello-world", HelloWorldComponent, HelloWorldViewModel);

application.start();