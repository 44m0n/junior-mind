import { Injectable } from '@nestjs/common';

@Injectable()
export class AppService {
  roots() {
    return 'This is the main page';
  }
}
        