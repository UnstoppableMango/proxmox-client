#!/usr/bin/env ts-node

import * as fs from 'fs/promises';
import glob from 'glob';
import * as path from 'path';
import { promisify } from 'util';

const globAsync = promisify(glob);

(async function () {
    const manifests: string[] = await globAsync('src/*/generated/.openapi-generator/FILES');

    for (let i = 0; i < manifests.length; i++) {
        const manifest = manifests[i];
        const buffer = await fs.readFile(manifest);
        const text: string = buffer.toString();
        const base = manifest.split(path.sep).slice(0, 3).join(path.sep);

        const getPath = (f: string) => path.resolve(path.join(__dirname, '..', base, f));

        const files = text.trim().split('\n').map(getPath);

        await Promise.all(files.map(async f => await fs.rm(f)));
        await fs.rm(getPath('.openapi-generator/FILES'));
        await fs.rm(getPath('.openapi-generator/VERSION'));
    }
}());
