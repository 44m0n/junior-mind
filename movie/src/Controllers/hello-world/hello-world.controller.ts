import { Controller, Get } from '@nestjs/common';

@Controller('hello-world')
export class HelloWorldController {

    @Get()
    root(): string {
        return "helloisdjo";
    }

    @Get('Welcome')
    welcome(): string {
        return "welcome action";
    }

}
